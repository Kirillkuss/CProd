using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace CProd;

public partial class PatientCotroller{

    public static void Rest( WebApplication app ){
        app.MapGet("/patient",  () => {
                object? response = null;
                using (KlinikaContext db = new KlinikaContext()){
                        response = db.Patients.Include( d => d.Document).ToList();
                    }
                return response; })
            .WithTags("2. Patients")
            .WithName("patients")
            .WithDescription("Получение списка пациентов")
            .WithOpenApi(operation => new(operation){ Summary = "Получение списка пациентов"})
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
            .WithOpenApi(operation => new(operation){ Summary = "Получение пациента по ИД",})
            .Produces<Patient>(StatusCodes.Status200OK)
            .Produces<BaseError>(StatusCodes.Status404NotFound)
            .Produces<BaseError>(StatusCodes.Status500InternalServerError);   
    }
}