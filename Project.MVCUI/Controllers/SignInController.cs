using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.COMMON;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using Project.VM.VMClasses;

namespace Project.MVCUI.Controllers
{
    public class SignInController : Controller
    {
        readonly IAppUserManager _iAppUser;
        public SignInController(IAppUserManager iAppUser)
        {
            _iAppUser = iAppUser;
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AppUserVM appUser)
        {
            AppUser appUserDomain = await _iAppUser.FirstOrDefaultAsync(x => x.Email == appUser.Email);
            if (await _iAppUser.CheckPasswordAsync(appUserDomain, appUser.Password) && appUserDomain.Status == DataStatus.Updated)
            {
                IList<string> roles = await _iAppUser.GetRolesAsync(appUserDomain);
                if (roles.Contains("Admin"))
                {
                    return RedirectToAction("ListCategories", "Category", new { Area = "Admin" });
                }
                else if (roles.Contains("Member"))
                {
                    return RedirectToAction("Privacy", "SignIn");
                }
            }
            else if (await _iAppUser.CheckPasswordAsync(appUserDomain, appUser.Password) && appUserDomain.Status != DataStatus.Updated)
            {
                TempData["Message"] = "Lütfen Mailinizi onaylayın";
                return View();
            }
            TempData["Message"] = "Boyle bir üyelik yok";
            return View();
        }
        [Authorize(Roles = "Member")]
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> GetMail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetMail(AppUserVM appUser)
        {
            if (await _iAppUser.AnyAsync(x =>x.Email.Contains(appUser.Email)))
            {
                AppUser appUserDomain = await _iAppUser.FirstOrDefaultAsync(x =>x.Email.Contains(appUser.Email));
                string body = $"http://localhost:5270/SignIn/ResetPassword?id={appUserDomain.Id} linkine tıklayınız";
                EMailService.Send(appUser.Email,body:body);
                TempData["Redirect"] = "Mailinize gelen linkden Sifrenizi sıfırlayın";
                return View();
            }
            TempData["Redirect"] = "Mailiniz uyuşmuyor";
            return View();
        }
        public async Task<IActionResult> ResetPassword(int id)
        {
            return View();
        }
        public async Task<IActionResult> ResetPassword(AppUserVM appUser)
        {
            AppUser appUserDomain = await _iAppUser.FindAsync(appUser.ID);
            appUserDomain.PasswordHash = appUser.Password;
            await _iAppUser.UpdateAsync(appUserDomain);
            return RedirectToAction("Login");
        }
    }
}
