using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace CProd;
public partial class TreatmentCotroller{

    public static void Rest( WebApplication app ){
        app.MapGet("/treatments", () => {
                var response = new List<Treatment>();
                using (KlinikaContext db = new KlinikaContext()){
                    response = db.Treatments.Include( d => d.Drug )
                                            .ThenInclude( d =>d.DrugTreatment )
                                            .Include( r => r.RehabilitationSolution )
                                            .Include( d => d.Doctor )
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
                    response = db.Treatments.Include( d => d.Drug )
                                            .ThenInclude( d =>d.DrugTreatment )
                                            .Include( r => r.RehabilitationSolution )
                                            .Include( d => d.Doctor )
                                            .FirstOrDefault(p => p.IdTreatment == id);
                }
                return response; })
            .WithTags("7. Treatments")
            .WithName("/treatments/{id}")
            .WithOpenApi(operation => new(operation){ Summary = "Получение по ИД лечение пациента", Description = "Получение по ИД лечение пациента" })
            .Produces<Treatment>(StatusCodes.Status200OK)
            .Produces<BaseError>(StatusCodes.Status404NotFound)
            .Produces<BaseError>(StatusCodes.Status500InternalServerError);    
    }
}