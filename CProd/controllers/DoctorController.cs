using System.ComponentModel;

namespace CProd;

public partial class DoctorController{

    public static void Rest(WebApplication app){
        app.MapGet("/doctors",  () => {
                object? response = null;
                using (KlinikaContext db = new KlinikaContext()){
                        response = db.Doctors.ToList();
                    }
                return response; })
            .WithTags("1. Doctors")
            .WithName("doctors")
            .WithDescription("Получение списка врачей")
            .WithOpenApi(operation => new(operation){ Summary = "Получение списка врачей"})
            .Produces<List<Doctor>>(StatusCodes.Status200OK)
            .Produces<BaseError>(StatusCodes.Status404NotFound)
            .Produces<BaseError>(StatusCodes.Status500InternalServerError);

        app.MapGet("/doctors/{id}",  ( [DefaultValue("1")]  int id ) => {
                object? response = null;
                using (KlinikaContext db = new KlinikaContext()){
                        response = db.Doctors.FirstOrDefault(p => p.IdDoctor == id);
                    }
                return response; })
            .WithTags("1. Doctors")
            .WithName("/doctors/{id}")
            .WithDescription("Получение доктора по ИД")
            .WithOpenApi(operation => new(operation){ Summary = "Получение доктора по ИД"})
            .Produces<Doctor>(StatusCodes.Status200OK)
            .Produces<BaseError>(StatusCodes.Status404NotFound)
            .Produces<BaseError>(StatusCodes.Status500InternalServerError);
    }

}