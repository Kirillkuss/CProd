using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace CProd;
public partial class CardPatientCotroller{

    public static void Rest( WebApplication app ){
        app.MapGet("/card-patients", () => {
                object? response = null;
                using (KlinikaContext db = new KlinikaContext()){
                    response = db.CardPatients.Include( d => d.Patient.Document )
                                            .Include( p => p.Patient )
                                            .Include( d => d.TypeComplaints ).ThenInclude(  s =>s.Complaint )
                                            .ToList();
                    }
                return response; })
            .WithTags("4. Card Patients")
            .WithName("card-patients")
            .WithOpenApi(operation => new(operation){ Summary = "Получение списка карт паицентов", Description = "Получение списка карт пациентов" })
            .Produces<List<CardPatient>>(StatusCodes.Status200OK)
            .Produces<BaseError>(StatusCodes.Status404NotFound)
            .Produces<BaseError>(StatusCodes.Status500InternalServerError);

        app.MapPost("/card-patients", (CardPatient cardPatient ) => {
                object? response = null;
                using (KlinikaContext db = new KlinikaContext()){
                    response = db.CardPatients.Include( d => d.Patient.Document )
                                            .Include( p => p.Patient )
                                            .Include( d => d.TypeComplaints ).ThenInclude(  s =>s.Complaint )
                                            .ToList();
                    }
                return response; })
            .WithTags("4. Card Patients")
            .WithName("/card-patients")
            .WithOpenApi(operation => new(operation){ Summary = "Добавление карты пациента", Description = "Добавление карты пациента" })
            .Produces<List<CardPatient>>(StatusCodes.Status200OK)
            .Produces<BaseError>(StatusCodes.Status404NotFound)
            .Produces<BaseError>(StatusCodes.Status500InternalServerError);
    }
    

}