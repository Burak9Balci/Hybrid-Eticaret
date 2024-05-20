using Microsoft.AspNetCore.Identity;
using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(MyContext db, UserManager<AppUser> userManager,SignInManager<AppUser> signIn) : base(db)
        {
            _signIn = signIn;
            _uManger = userManager;
        }
        readonly SignInManager<AppUser> _signIn;
        readonly UserManager<AppUser> _uManger;
        public async Task<IdentityResult> AddUserAsync(AppUser user)
        {
           IdentityResult result = await _uManger.CreateAsync(user,user.PasswordHash);
           return result;
        }

        public async Task AddToRoleAsync(AppUser appUser, string appRole)
        {
            await _uManger.AddToRoleAsync(appUser, appRole);
        }

        public async Task<SignInResult> PasswordSignInAsync(AppUser appUser, string password, bool isPersistent, bool lockoutOnFailure)
        {
            SignInResult result = await _signIn.PasswordSignInAsync(appUser,password,isPersistent,lockoutOnFailure);
            return result;
        }
    }
}
