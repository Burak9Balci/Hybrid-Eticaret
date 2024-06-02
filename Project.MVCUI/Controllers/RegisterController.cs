using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class RegisterController : Controller
    {
        private readonly ILogger<RegisterController> _logger;
        readonly IAppUserManager _iAppUser;
        readonly IAppRoleManager _appRole;
        private RoleManager<AppRole> _roleManager;

        public RegisterController(ILogger<RegisterController> logger,IAppUserManager appUser, RoleManager<AppRole> roleManager, IAppRoleManager appRole)
        {
            _roleManager = roleManager;
            _iAppUser = appUser;
            _logger = logger;
            _appRole = appRole;
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserVM appUser)
        {
            if (ModelState.IsValid)
            {
                Guid actCode = Guid.NewGuid();
                AppUser app1 = new()
                {
                    UserName = appUser.UserName,
                    Email = appUser.Email,
                    ActivationCode = actCode,
                    PasswordHash = appUser.PasswordHash,
                    Agree = appUser.Agree,
                };
                if (await _iAppUser.AddUserAsync(app1))
                {
                    await _iAppUser.AddToRoleAsync(app1, await _appRole.FirstOrDefaultAsync(x => x.Name.Contains("Member")));
                    string body = $"http://localhost:5270/Register/ConfirmEmail?actCode={actCode}&id={app1.Id} linkine týklayýnýz";
                    EMailService.Send(appUser.Email, body: body);
                    return RedirectToAction("RedirectPanel");
                }
            }
            return View(appUser);
        }       
        public async Task<IActionResult> ConfirmEmail(Guid actCode, int id)
        {
            AppUser user = await _iAppUser.FindAsync(id);
            await _iAppUser.UpdateAsync(user);
            TempData["Mesaj"] = "Mailiniz Onaylandý";
            return RedirectToAction("Login","SignIn");
        }
        public async Task<IActionResult> Deal()
        {
            return View();
        }
        public async Task<IActionResult> RedirectPanel()
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
