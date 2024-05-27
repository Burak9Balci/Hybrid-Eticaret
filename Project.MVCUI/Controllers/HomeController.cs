using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.COMMON;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using Project.MVCUI.Models;
using Project.VM.VMClasses;
using System.Diagnostics;

namespace Project.MVCUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly IAppUserManager _iAppUser;
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
            Guid actCode = Guid.NewGuid();  
            AppUser app1 = new()
            {
               UserName = appUser.UserName,
               Email = appUser.Email,
               ActivationCode = actCode
            };
            if (await _iAppUser.AddUserAsync(app1))
            {
                await _iAppUser.AddToRoleAsync(app1,"Member");
                string body = $"http://localhost:5270/Home/ConfirmEmail?specId={actCode}&id={app1.Id} linkine týklayýnýz";
                EMailService.Send(appUser.Email,body:body);
                return RedirectToAction("RedirectPanel");
            }
            TempData["Message"] = "Boyle bir üyelik yok";
            return View();
        }
        public async Task<IActionResult> SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserVM appUser)
        {
            AppUser appUserDomain = await _iAppUser.FirstOrDefaultAsync(x =>x.UserName == appUser.UserName);
            if (await _iAppUser.CheckPasswordAsync(appUserDomain,appUser.Password) && appUserDomain.Status == DataStatus.Updated)
            {
                IList<string> roles = await _iAppUser.GetRolesAsync(appUserDomain);
                if (roles.Contains("Admin"))
                {
                    return RedirectToAction("ListCategories","Category",new {Area = "Admin"});
                }
                else if (roles.Contains("Member"))
                {
                    return RedirectToAction("Privacy", "Home");
                }
            }
            else if (await _iAppUser.CheckPasswordAsync(appUserDomain, appUser.Password) && appUserDomain.Status != DataStatus.Updated)
            {
                return RedirectToAction("RedirectPanel");
            }
            TempData["Message"] = "Boyle bir üyelik yok";
            return View();
        }
        public async Task<IActionResult> ConfirmEmail(Guid actCode, int id)
        {
            AppUser user = await _iAppUser.FindAsync(id);
            await _iAppUser.UpdateAsync(user);
            TempData["Mesaj"] = "Mailiniz Onaylandý";
            return RedirectToAction("SignIn");
        }
        [Authorize(Roles ="Member")]
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult RedirectPanel()
        {
            return View();
        }
        public IActionResult MailPanel()
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
