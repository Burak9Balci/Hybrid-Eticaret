using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.MVCUI.Models;
using Project.VM.VMClasses;
using System.Diagnostics;

namespace Project.MVCUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IAppUserManager _iAppUser;
        public HomeController(ILogger<HomeController> logger,IAppUserManager appUser)
        {
            _iAppUser = appUser;
            _logger = logger;
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserVM appUser)
        {
            return View();
        }
        public async Task<IActionResult> SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserVM appUser)
        {
            return View();
        }
        public async Task<IActionResult> ConfirmEmail(Guid specId, int id)
        {
            return RedirectToAction("Register");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
