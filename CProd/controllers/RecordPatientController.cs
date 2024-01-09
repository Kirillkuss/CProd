using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace CProd;

public partial class RecordPatientCotroller{

    public static void Rest( WebApplication app ){
        app.MapGet("/record-patients", () => {
                object? response = null;
                using (KlinikaContext db = new KlinikaContext()){
                    response = db.RecordPatients.Include( d => d.Doctor ).ToList();
                }
                return response; })
            .WithTags("5. Record Patients")
            .WithName("record-patients")
            .WithOpenApi(operation => new(operation){ Summary = "Получение списка записей паицентов", Description = "Получение списка записей пациентов" })
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
            .WithOpenApi(operation => new(operation){ Summary = "Получение списка записей паицентов", Description = "Получение списка записей пациентов" })
            .Produces<RecordPatient>(StatusCodes.Status200OK)
            .Produces<BaseError>(StatusCodes.Status404NotFound)
            .Produces<BaseError>(StatusCodes.Status500InternalServerError);   
    }
}    