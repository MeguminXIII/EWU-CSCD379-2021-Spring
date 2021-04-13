using Microsoft.AspNetCore.Mvc;

namespace SecretSanta.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /*
        public IActionResult Page()
        {
            return View();
        }
        */
    }
}


//cal:The package.json file was generated with defauts using "npm init". Used for css. Dependencies and test were copy pasted.
//placed comment here since no comments allowed in json files.
//the node_modules dir was made with a "npm i". Which installes the dependencies.