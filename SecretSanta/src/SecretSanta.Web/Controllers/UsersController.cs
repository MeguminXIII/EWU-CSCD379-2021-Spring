using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SecretSanta.Web.ViewModels;
namespace SecretSanta.Web.Controllers
{
    public class UsersController : Controller
    {
        static List<UserViewModel> Users = new List<UserViewModel>{
            new UserViewModel{FirstName = "Rob", LastName = "Boss"},
            new UserViewModel{FirstName = "Rick", LastName= "Vames"}
        };
        public IActionResult Index()
        {
            //return View();
            return View(Users);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]//cal:This maps the below version to the html method="post"
        public IActionResult Create(UserViewModel vModel)
        {
            if(ModelState.IsValid)//cal:if data is invalid goes back to create page, but also preserves data.
            {
                Users.Add(vModel);
                return RedirectToAction(nameof(Index));//cal: the nameof(Index) part helps give us a compiler warning if the Index name changes.
            }
            return View(vModel);
        }

        public IActionResult Edit(int id)
        {
            Users[id].Id = id;
            return View(Users[id]);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel vModel)
        {
            if(ModelState.IsValid)
            {
                Users[vModel.Id] = vModel;
                return RedirectToAction(nameof(Index));
            }
            return View(vModel);
        }

        public IActionResult Delete(int id)
        {
            Users.RemoveAt(id);
            return RedirectToAction(nameof(Index));
        }
    }
}