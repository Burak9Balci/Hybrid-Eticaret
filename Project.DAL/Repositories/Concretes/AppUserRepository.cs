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
        
        public AppUserRepository(MyContext db, UserManager<AppUser> userManager) : base(db)
        {
          
            
            _uManger = userManager;
        }
      
        readonly UserManager<AppUser> _uManger;
        public async Task<IdentityResult> AddUserAsync(AppUser user)
        {
           IdentityResult result = await _uManger.CreateAsync(user,user.PasswordHash);
           return result;
        }

        public async Task AddToRoleAsync(AppUser appUser, AppRole appRole)
        {

            List<AppUserRole> allRoles = new List<AppUserRole>()
            {
                new AppUserRole
                {
                    Role = appRole,
                    User = appUser
                }
            };
            appUser.UserRoles = allRoles;
        }

        public async Task<bool> CheckPasswordAsync(AppUser appUser, string password)
        {
            bool result = await _uManger.CheckPasswordAsync(appUser, password);
            return result;
          
        }

        public async Task<IList<string>> GetRolesAsync(AppUser appUser)
        {
            IList<string> roles = await _uManger.GetRolesAsync(appUser);
            return roles;
        }
    }
}
