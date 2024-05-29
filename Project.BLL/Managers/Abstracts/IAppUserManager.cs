using Microsoft.AspNetCore.Identity;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Abstracts
{
    public interface IAppUserManager : IManager<AppUser>
    {
        Task<bool> AddUserAsync(AppUser user);
        Task AddToRoleAsync(AppUser appUser,AppRole appRole);
        Task<bool> CheckPasswordAsync(AppUser appUser, string password);
        Task<IList<string>> GetRolesAsync(AppUser appUser);
    }
}
