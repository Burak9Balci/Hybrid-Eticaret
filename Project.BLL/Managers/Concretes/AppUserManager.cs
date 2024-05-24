using Microsoft.AspNetCore.Identity;
using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class AppUserManager : BaseManager<AppUser>, IAppUserManager
    {
        IAppUserRepository _iAppUser;
        IAppRoleManager _iAppRole;
        public AppUserManager(IAppUserRepository iAppUser,IAppRoleManager iAppRole) : base(iAppUser)
        {
            _iAppUser = iAppUser;
            _iAppRole = iAppRole;
        }

        public async Task AddToRoleAsync(AppUser appUser, string appRole)
        {
            
            if (await _iAppRole.FirstOrDefaultAsync(x => x.Name == appRole) != null) await _iAppUser.AddToRoleAsync(appUser,appRole);
            else
            {
                _iAppUser.Warning("Role bulunamadı");
            }
        }

        public async Task<bool> AddUserAsync(AppUser user)
        {
            IdentityResult result = await _iAppUser.AddUserAsync(user);
            if (result.Succeeded)
            {
                return true;
            }
            _iAppUser.Warning("Ekleme Basarısız");
            return false;
        }

        public async Task<bool> CheckPasswordAsync(AppUser appUser, string password)
        {
            if (await _iAppUser.CheckPasswordAsync(appUser, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IList<string>> GetRolesAsync(AppUser appUser)
        {
          return await _iAppUser.GetRolesAsync(appUser);
        }
    }
}
