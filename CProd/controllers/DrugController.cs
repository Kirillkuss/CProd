using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace CProd;
public partial class DrugCotroller{

    public static void Rest( WebApplication app ){
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
            .WithOpenApi(operation => new(operation){ Summary = "Получение списка лекарств", Description = "Получение списка лекарств" })
            .Produces<List<Drug>>(StatusCodes.Status200OK)
            .Produces<BaseError>(StatusCodes.Status404NotFound)
            .Produces<BaseError>(StatusCodes.Status500InternalServerError);
    }
}