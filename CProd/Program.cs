using System.Reflection;
using CProd;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>{
    options.SwaggerDoc("v1", new OpenApiInfo{
        Version = "v1",
        Title = "CRpod",
        Description = "RESTful an ASP.NET",
        Contact = new OpenApiContact{
            Name = "git",
            Url = new Uri("https://github.com/Kirillkuss")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/cars", () => {
        object? response = null;
        using (PostgresContext db = new PostgresContext()){
                response = db.Cars.ToList();
            }
        return response; })
    .WithTags("Cars")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение списка авто",
        Description = "Получение списка авто"
    });

app.MapGet("/cars/{id}", (int id) => {
        Car? car = null;
        using (PostgresContext db = new PostgresContext()){
                car  = db.Cars.Find(id);
            }
        return car is Car response? Results.Ok( response ) : Results.NotFound(); })
    .WithTags("Cars")
    .WithOpenApi(operation => new(operation){
            Summary = "Получение авто по ИД",
            Description = "Получение авто по ИД"})
    .Produces<Car>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound);    

app.MapGet("/users",  () => {
        object? response = null;
        using (PostgresContext db = new PostgresContext()){
                response = db.Users.ToList();
            }
        return response; })
    .WithTags("Users")
    .WithName("users")
    .WithDescription("Получение списка пользователей")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение списка пользователей",
    });

app.MapGet("/users/{id}",  (int id) => {
        User? user = null;
        using (PostgresContext db = new PostgresContext()){
                user = db.Users.Find(id);
            }
        return user is User response? Results.Ok( response ) : Results.NotFound(); })
    .WithTags("Users")
    .WithDescription("Получение пользователя по ИД")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение пользователя по ИД",})
    .Produces<User>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound);


app.MapGet("/animals", () => {
        object? response = null;
        using (PostgresContext db = new PostgresContext()){
            response = db.Animals.ToList();
        }
        return response; })
    .WithTags("Animals")
    .WithName("animals")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение списка питомцев",
        Description = "Получение списка питомцев"
    });

app.MapGet("/animals/{id}", (int id) => {
        Animal? animal = null;
        using (PostgresContext db = new PostgresContext()){
                animal = db.Animals.Find( id );
            }
        return animal is Animal response? Results.Ok( response ) : Results.NotFound();})
    .WithTags("Animals")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение питомца по ИД",
        Description = "Получение питомца по ИД"})
    .Produces<Animal>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound);

app.Run();

