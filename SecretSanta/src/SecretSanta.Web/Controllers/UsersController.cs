using Microsoft.AspNetCore.Mvc;
using SecretSanta.Web.Data;
using SecretSanta.Web.ViewModels;
using SecretSanta.Web.Api;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace SecretSanta.Web.Controllers
{
    public class UsersController : Controller
    {
        public IUsersClient UserClient { get; }

        public UsersController(IUsersClient userClient){
            UserClient = userClient ?? throw new ArgumentNullException(nameof(userClient));
        }

        public async Task<IActionResult> Index()
        {
            ICollection<DtoUser?> users = (ICollection<DtoUser?>)await UserClient.GetAllAsync();
            List<UserViewModel> viewModel = new();
            foreach (DtoUser dtoUser in users){
                if((dtoUser?.Id ?? null) is null) continue;
                viewModel.Add(new UserViewModel{
                    Id = (int)dtoUser!.Id!,
                    FirstName = dtoUser.FirstName,
                    LastName = dtoUser.LastName
                });
            }
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await UserClient.PostAsync(new DtoUser{
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Id = viewModel.Id
                });
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            DtoUser newUser = await UserClient.GetAsync(id);
            
            return View(new UserViewModel{
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await UserClient.PutAsync(viewModel.Id, new DtoUser{
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Id = viewModel.Id
                });
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if(id >= 0)
                await UserClient.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}