using Microsoft.AspNetCore.Mvc;

namespace CProd;

public class HomeController : Controller{

        //path in index.cshtml
        public IActionResult Index(){
            return View(); 
        } 

        // get controller
        [HttpGet]
        public List<Animal> Pets(){
            List<Animal>? response = null;
            using (PostgresContext db = new PostgresContext()){
                response = db.Animals.ToList();
            }
            return response;
        }
    }