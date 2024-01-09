using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace CProd;
public partial class RehabilitationSolutionCotroller{

    public static void Rest( WebApplication app ){
        app.MapGet("/rehabilitation-solutions", () => {
                object? response = null;
                using (KlinikaContext db = new KlinikaContext()){
                    response = db.RehabilitationSolutions.ToList();
                }
                return response; })
            .WithTags("9. Rehabilitation Solutions")
            .WithName("rehabilitation-solutions")
            .WithOpenApi(operation => new(operation){ Summary = "Получение списка реаблитационных лечений", Description = "Получение списка  реаблитационных лечений" })
            .Produces<List<RehabilitationSolution>>(StatusCodes.Status200OK)
            .Produces<BaseError>(StatusCodes.Status404NotFound)
            .Produces<BaseError>(StatusCodes.Status500InternalServerError);       
    }
}    