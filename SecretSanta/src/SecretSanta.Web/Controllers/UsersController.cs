using Microsoft.AspNetCore.Mvc;
using SecretSanta.Web.Data;
using SecretSanta.Web.ViewModels;
using SecretSanta.Web.Api;
using System.Threading.Tasks;

namespace SecretSanta.Web.Controllers
{
    public class UsersController : Controller
    {
        public IUsersClient UserClient { get; }
        public IActionResult Index()
        {
            return View(MockData.Users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.Users.Add(viewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            return View(MockData.Users[id]);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await UserClient.PutAsync(viewModel.Id, new DtoUser{
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName
                });
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            MockData.Users.RemoveAt(id);
            return RedirectToAction(nameof(Index));
        }
    }
}