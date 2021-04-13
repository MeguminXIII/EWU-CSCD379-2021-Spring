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
            return View(MockData.GiftsList);
        }

        [HttpPost]
        public IActionResult Create(GiftViewModel vm){
            if(ModelState.IsValid){
                MockData.GiftsList.Add(vm);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        public IActionResult Edit(int id)
        {
            return View(MockData.GiftsList[id]);
        }

        [HttpPost]
        public IActionResult Edit(GiftViewModel vm){
            if(ModelState.IsValid){
                MockData.GiftsList[vm.GiftId] = vm;
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult Delete(int ID){
            MockData.GiftsList.RemoveAt(ID);
            return RedirectToAction(nameof(Index));
        }
    }
}