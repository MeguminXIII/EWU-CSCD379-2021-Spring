using Microsoft.AspNetCore.Mvc;

namespace UserGroup.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Page()
        {
            return View();
        }
    }
}