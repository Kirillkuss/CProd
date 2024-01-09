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

	
builder.Services.AddControllers(); //поддержка контроллеров
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

    DoctorController.Rest( app );
    PatientCotroller.Rest( app );
    DocumentCotroller.Rest( app );
    CardPatientCotroller.Rest( app );
    RecordPatientCotroller.Rest( app );
    ComplaintCotroller.Rest( app );
    TreatmentCotroller.Rest( app );
    DrugCotroller.Rest( app );
    RehabilitationSolutionCotroller.Rest( app );

// get Index.cshtml
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// get cotroller 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Pets}/{id?}");              

app.Run();

