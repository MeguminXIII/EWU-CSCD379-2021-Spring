using Microsoft.AspNetCore.Mvc;
using SecretSanta.Web.ViewModels;
using System.Collections.Generic;

namespace SecretSanta.Web.Controllers
{
    public class GroupsController : Controller
    {
        static List<GroupViewModel> Groups = new List<GroupViewModel>{
            new GroupViewModel{GroupName = "Night Owls"}   
        };
        
        public IActionResult Index()
        {
            return View(Groups);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(GroupViewModel vModel)
        {
            if(ModelState.IsValid)
            {
                Groups.Add(vModel);
                return RedirectToAction(nameof(Index));
            }
            return View(vModel);
        }

        public IActionResult Edit(int id)
        {
            return View(Groups[id]);
        }

        [HttpPost]
        public IActionResult Edit(GroupViewModel vModel)
        {
            if(ModelState.IsValid)
            {
                Groups[vModel.Id] = vModel;
                return RedirectToAction(nameof(Index));
            }
            return View(vModel);
        }

        public IActionResult Delete(int id)
        {
            Groups.RemoveAt(id);
            return RedirectToAction(nameof(Index));
        }
    }
}