using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Web.Data;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Controllers
{
    public class GroupsController : Controller
    {
        public IActionResult Create(){
            return View();
        }

        public IActionResult Index(){
            return View(MockData.Groups);
        }

        [HttpPost]
        public IActionResult Create(GroupViewModel vm){
            if(ModelState.IsValid){
                MockData.Groups.Add(vm);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        public IActionResult Edit(int id){
                MockData.Groups[id].ID = id;
                return View(MockData.Groups[id]);
        }

        [HttpPost]
        public IActionResult Edit(GroupViewModel vm){
            if(ModelState.IsValid){
                MockData.Groups[vm.ID] = vm;
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult Delete(int id){
            MockData.Groups.RemoveAt(id);
            return RedirectToAction(nameof(Index));
        }
    }
}