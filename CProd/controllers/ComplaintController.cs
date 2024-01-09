using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace CProd;

public partial class ComplaintCotroller{

       public static void Rest( WebApplication app ){
            app.MapGet("/complaints",  () => {
                    object? response = null;
                    using (KlinikaContext db = new KlinikaContext()){
                            response = db.Complaints.ToList();
                        }
                    return response; })
                .WithTags("6. Сomplaints")
                .WithName("complaints")
                .WithDescription("Получение списка жалоб")
                .WithOpenApi(operation => new(operation){ Summary = "Получение списка жалоб" })
                .Produces<List<Complaint>>(StatusCodes.Status200OK)
                .Produces<BaseError>(StatusCodes.Status404NotFound)
                .Produces<BaseError>(StatusCodes.Status500InternalServerError);

            app.MapGet("/type-complaints",  () => {
                    object? response = null;
                    using (KlinikaContext db = new KlinikaContext()){
                            response = db.TypeComplaints.Include( d =>d.Complaint).ToList();
                        }
                    return response; })
                .WithTags("6. Сomplaints")
                .WithName("type-complaints")
                .WithDescription("Получение списка под жалоб")
                .WithOpenApi(operation => new(operation){ Summary = "Получение списка под жалоб" })
                .Produces<List<TypeComplaint>>(StatusCodes.Status200OK)
                .Produces<BaseError>(StatusCodes.Status404NotFound)
                .Produces<BaseError>(StatusCodes.Status500InternalServerError);  
       }
}