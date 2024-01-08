using Microsoft.AspNetCore.Mvc;

namespace CProd;

public class HomeController : Controller{

        //path in index.cshtml
        public IActionResult Index(){
            return View(); 
        } 

        // get controller
        [HttpGet]
        public List<Document> Pets(){
            List<Document>? response = null;
            using (PostgresContext db = new PostgresContext()){
                response = db.Documents.ToList();
            }
            return response;
        }
    }