using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SecretSanta.Web.ViewModels;
using SecretSanta.Web.Data;

namespace SecretSanta.Web.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Create(){
            return View();
        }

        public IActionResult Index(){
            return View(MockData.Users);
        }

        [HttpPost]
        public IActionResult Create(UserViewModel vm){
            if(ModelState.IsValid){
                MockData.Users.Add(vm);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        public IActionResult Edit(int id){
            MockData.Users[id].UserID = id;
            return View(MockData.Users[id]);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel vm){
            if(ModelState.IsValid){
                MockData.Users[vm.UserID] = vm;
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult Delete(int ID){
            MockData.Users.RemoveAt(ID);
            return RedirectToAction(nameof(Index));
        }
    }
}