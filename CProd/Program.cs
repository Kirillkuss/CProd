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
        using (KlinikaContext db = new KlinikaContext()){
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

app.MapGet("/patient",  () => {
        object? response = null;
        using (KlinikaContext db = new KlinikaContext()){
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
        using (KlinikaContext db = new KlinikaContext()){
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
        using (KlinikaContext db = new KlinikaContext()){
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
        using (KlinikaContext db = new KlinikaContext()){
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

app.MapGet("/card-patients", () => {
        object? response = null;
        using (KlinikaContext db = new KlinikaContext()){
            //.Include( d => d.TypeComplaints )
            response = db.CardPatients.Include( p => p.Patient )
                                      .Include( d => d.Patient.Document )
                                      .ToList();
        }
        return response; })
    .WithTags("4. Card Patients")
    .WithName("card-patients")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение списка карт паицентов",
        Description = "Получение списка карт пациентов" })
    .Produces<List<CardPatient>>(StatusCodes.Status200OK)
    .Produces<BaseError>(StatusCodes.Status404NotFound)
    .Produces<BaseError>(StatusCodes.Status500InternalServerError);

app.MapGet("/record-patients", () => {
        object? response = null;
        using (KlinikaContext db = new KlinikaContext()){
            response = db.RecordPatients.Include( d => d.Doctor ).ToList();
        }
        return response; })
    .WithTags("5. Record Patients")
    .WithName("record-patients")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение списка записей паицентов",
        Description = "Получение списка записей пациентов" })
    .Produces<List<RecordPatient>>(StatusCodes.Status200OK)
    .Produces<BaseError>(StatusCodes.Status404NotFound)
    .Produces<BaseError>(StatusCodes.Status500InternalServerError);

app.MapGet("/record-patients/{id}", ( [DefaultValue("1")] int id) => {
        object? response = null;
        using (KlinikaContext db = new KlinikaContext()){
            response = db.RecordPatients.Include( d => d.Doctor ).FirstOrDefault(p => p.IdRecord == id);
        }
        return response; })
    .WithTags("5. Record Patients")
    .WithName("record-patients/{id}")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение списка записей паицентов",
        Description = "Получение списка записей пациентов" })
    .Produces<RecordPatient>(StatusCodes.Status200OK)
    .Produces<BaseError>(StatusCodes.Status404NotFound)
    .Produces<BaseError>(StatusCodes.Status500InternalServerError);   

 app.MapGet("/complaints",  () => {
        object? response = null;
        using (KlinikaContext db = new KlinikaContext()){
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
        using (KlinikaContext db = new KlinikaContext()){
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

app.MapGet("/treatments", () => {
        var response = new List<Treatment>();
        using (KlinikaContext db = new KlinikaContext()){
            response = db.Treatments.Include( d => d.Drug ).Include( r => r.RehabilitationSolution ).Include( d => d.Doctor )
                                    .Include( d => d.Drug.DrugTreatment )
                                    .ToList();
        }
        return response; })
    .WithTags("7. Treatments")
    .WithName("treatments")
    .WithOpenApi(operation => new(operation){ Summary = "Получение списка лечений пациентов", Description = "Получение списка лечений пациентов" })
    .Produces<List<Treatment>>(StatusCodes.Status200OK)
    .Produces<BaseError>(StatusCodes.Status404NotFound)
    .Produces<BaseError>(StatusCodes.Status500InternalServerError);

app.MapGet("/treatments/{id}", ([DefaultValue("1")] int id) => {
        object? response = null;
        using (KlinikaContext db = new KlinikaContext()){
            response = db.Treatments.Include( d => d.Drug ).Include( r => r.RehabilitationSolution ).Include( d => d.Doctor )
                                    .Include( d => d.Drug.DrugTreatment )
                                    .FirstOrDefault(p => p.IdTreatment == id);
        }
        return response; })
    .WithTags("7. Treatments")
    .WithName("/treatments/{id}")
    .WithOpenApi(operation => new(operation){ Summary = "Получение по ИД лечение пациента", Description = "Получение по ИД лечение пациента" })
    .Produces<Treatment>(StatusCodes.Status200OK)
    .Produces<BaseError>(StatusCodes.Status404NotFound)
    .Produces<BaseError>(StatusCodes.Status500InternalServerError);    

app.MapGet("/drug-treatments", () => {
        object? response = null;
        using (KlinikaContext db = new KlinikaContext()){
            response = db.DrugTreatments.ToList();
        }
        return response; })
    .WithTags("8. Drug-treatments")
    .WithName("drug-treatments")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение списка медикаментозного лечения",
        Description = "Получение списка медикаментозного лечения" })
    .Produces<List<DrugTreatment>>(StatusCodes.Status200OK)
    .Produces<BaseError>(StatusCodes.Status404NotFound)
    .Produces<BaseError>(StatusCodes.Status500InternalServerError);

app.MapGet("/drug", () => {
        var response = new List<Drug>();
        using (KlinikaContext db = new KlinikaContext()){
            response = db.Drugs.Include( t => t.DrugTreatment ).ToList();
            Console.WriteLine(response);
        }
        return response; })
    .WithTags("8. Drug-treatments")
    .WithName("drug")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение списка лекарств",
        Description = "Получение списка лекарств" })
    .Produces<List<Drug>>(StatusCodes.Status200OK)
    .Produces<BaseError>(StatusCodes.Status404NotFound)
    .Produces<BaseError>(StatusCodes.Status500InternalServerError);

app.MapGet("/rehabilitation-solutions", () => {
        object? response = null;
        using (KlinikaContext db = new KlinikaContext()){
            response = db.RehabilitationSolutions.ToList();
        }
        return response; })
    .WithTags("9. Rehabilitation Solutions")
    .WithName("rehabilitation-solutions")
    .WithOpenApi(operation => new(operation){
        Summary = "Получение списка реаблитационных лечений",
        Description = "Получение списка  реаблитационных лечений" })
    .Produces<List<RehabilitationSolution>>(StatusCodes.Status200OK)
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

