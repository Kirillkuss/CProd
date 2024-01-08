using System.ComponentModel;
using System.Reflection;
using CProd;
using Microsoft.EntityFrameworkCore;
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

	
builder.Services.AddControllers(); //поддержка контроллеров
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/doctors",  () => {
        object? response = null;
        using (PostgresContext db = new PostgresContext()){
                response = db.Doctors.ToList();
            }
        return response; })
    .WithTags("1. Doctors")
    .WithName("doctors")
    .WithDescription("Получение списка врачей")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение списка врачей"})
    .Produces<List<Doctor>>(StatusCodes.Status200OK)
    .Produces<BaseError>(StatusCodes.Status404NotFound)
    .Produces<BaseError>(StatusCodes.Status500InternalServerError);

 app.MapGet("/complaints",  () => {
        object? response = null;
        using (PostgresContext db = new PostgresContext()){
                response = db.Complaints.ToList();
            }
        return response; })
    .WithTags("6. Сomplaints")
    .WithName("complaints")
    .WithDescription("Получение списка жалоб")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение списка жалоб"})
    .Produces<List<Complaint>>(StatusCodes.Status200OK)
    .Produces<BaseError>(StatusCodes.Status404NotFound)
    .Produces<BaseError>(StatusCodes.Status500InternalServerError);

app.MapGet("/type-complaints",  () => {
        object? response = null;
        using (PostgresContext db = new PostgresContext()){
                response = db.TypeComplaints.ToList();
            }
        return response; })
    .WithTags("6. Сomplaints")
    .WithName("type-complaints")
    .WithDescription("Получение списка под жалоб")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение списка под жалоб"})
    .Produces<List<TypeComplaint>>(StatusCodes.Status200OK)
    .Produces<BaseError>(StatusCodes.Status404NotFound)
    .Produces<BaseError>(StatusCodes.Status500InternalServerError);              

app.MapGet("/patient",  () => {
        object? response = null;
        using (PostgresContext db = new PostgresContext()){
                response = db.Patients.Include( d => d.Document).ToList();
            }
        return response; })
    .WithTags("2. Patients")
    .WithName("patients")
    .WithDescription("Получение списка пациентов")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение списка пациентов"})
    .Produces<List<Patient>>(StatusCodes.Status200OK)
    .Produces<BaseError>(StatusCodes.Status404NotFound)
    .Produces<BaseError>(StatusCodes.Status500InternalServerError);  

app.MapGet("/patient/{id}",  ( [DefaultValue("1")] int id) => {
        Patient? patient = null;
        using (PostgresContext db = new PostgresContext()){
                patient = db.Patients.Include( d => d.Document).FirstOrDefault(p => p.IdPatient == id);
                //Console.WriteLine(patient);
            }
        return patient is Patient response? Results.Ok( response ) : Results.NotFound(); })
    .WithTags("2. Patients")
    .WithDescription("Получение пациента по ИД")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение пациента по ИД",})
    .Produces<Patient>(StatusCodes.Status200OK)
    .Produces<BaseError>(StatusCodes.Status404NotFound)
    .Produces<BaseError>(StatusCodes.Status500InternalServerError);   


app.MapGet("/documents", () => {
        object? response = null;
        using (PostgresContext db = new PostgresContext()){
            response = db.Documents.ToList();
        }
        return response; })
    .WithTags("3. Documents")
    .WithName("documents")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение списка документов",
        Description = "Получение списка документов" })
    .Produces<List<Document>>(StatusCodes.Status200OK)
    .Produces<BaseError>(StatusCodes.Status404NotFound)
    .Produces<BaseError>(StatusCodes.Status500InternalServerError);  

app.MapGet("/documents/{id}", ( [DefaultValue("1")] int id) => {
        Document? document = null;
        using (PostgresContext db = new PostgresContext()){
                document = db.Documents.Find( id );
            }
        return document is Document response? Results.Ok( response ) : Results.NotFound();})
    .WithTags("3. Documents")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение документа по ИД",
        Description = "Получение документа по ИД"})
    .Produces<Document>(StatusCodes.Status200OK)
    .Produces<BaseError>(StatusCodes.Status404NotFound)
    .Produces<BaseError>(StatusCodes.Status500InternalServerError);

// get Index.cshtml
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// get cotroller 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Pets}/{id?}");              

app.Run();

