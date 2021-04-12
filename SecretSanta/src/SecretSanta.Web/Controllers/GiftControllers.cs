using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Web.Data;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Controllers
{
    public class GiftsController : Controller
    {
        public IActionResult Create(){
            return View();
        }

        public IActionResult Index(){
            return View(MockData.Users);
        }

        [HttpPost]
        public IActionResult Create(GiftViewModel vm){
            if(ModelState.IsValid){
                MockData.GiftsList[vm.GiftId].Add(vm);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(GiftViewModel vm){
            if(ModelState.IsValid){
                MockData.GiftsList[vm.GiftId][vm.ID] = vm;
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult Delete(int usersID, int ID){
            MockData.GiftsList[usersID].RemoveAt(ID);
            return RedirectToAction(nameof(Index));
        }
    }
}