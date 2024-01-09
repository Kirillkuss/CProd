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
            using (KlinikaContext db = new KlinikaContext()){
                response = db.Documents.ToList();
            }
            return response;
        }
    }