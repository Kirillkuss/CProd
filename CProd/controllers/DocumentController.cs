using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace CProd;


public partial class DocumentCotroller{

    public static void Rest( WebApplication app ){
        app.MapGet("/documents", () => {
                object? response = null;
                using (KlinikaContext db = new KlinikaContext()){
                    response = db.Documents.ToList();
                }
                return response; })
            .WithTags("3. Documents")
            .WithName("documents")
            .WithOpenApi(operation => new(operation){ Summary = "Получение списка документов", Description = "Получение списка документов" })
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
        .WithOpenApi(operation => new(operation){ Summary = "Получение документа по ИД", Description = "Получение документа по ИД"})
        .Produces<Document>(StatusCodes.Status200OK)
        .Produces<BaseError>(StatusCodes.Status404NotFound)
        .Produces<BaseError>(StatusCodes.Status500InternalServerError);
    }
}