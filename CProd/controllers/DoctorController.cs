using System.ComponentModel;
using Microsoft.AspNetCore.Http.HttpResults;

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
                        if( response == null ){
                            return Results.Json( new BaseResponse( 404, "Документа с таким ИД не существует"), statusCode: 404);
                        }
                    }
                return response; })
            .WithTags("1. Doctors")
            .WithName("/doctors/{id}")
            .WithDescription("Получение доктора по ИД")
            .WithOpenApi(operation => new(operation){ Summary = "Получение доктора по ИД"})
            .Produces<Doctor>(StatusCodes.Status200OK)
            .Produces<BaseError>(StatusCodes.Status404NotFound)
            .Produces<BaseError>(StatusCodes.Status500InternalServerError);

            
        app.MapPost("/doctors",  ( Doctor doctor ) => {
                object? response = null;
                using (KlinikaContext db = new KlinikaContext()){
                    if( db.Doctors.Find( doctor.IdDoctor ) != null ){
                        return Results.Json( new BaseResponse( 400, "Документа с таким ИД уже существует"), statusCode: 400 );
                    }else{
                        db.Doctors.Add( doctor );
                        db.SaveChanges();
                        response = new BaseResponse( 201, "Доктор добавлен");
                    }
                }
                return  response; })
            .WithTags("1. Doctors")
            .WithName("/doctors")
            .WithDescription("Добавить доктора")
            .WithOpenApi(operation => new(operation){ Summary = "Добавить доктора"})
            .Produces<BaseResponse>(StatusCodes.Status200OK)
            .Produces<BaseError>(StatusCodes.Status404NotFound)
            .Produces<BaseError>(StatusCodes.Status500InternalServerError);
    }

}