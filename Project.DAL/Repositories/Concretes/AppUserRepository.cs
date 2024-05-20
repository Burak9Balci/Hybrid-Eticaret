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
        public AppUserRepository(MyContext db,UserManager<AppUser> userManager, IAppRoleRepository iAppRole) : base(db) 
        {
            _uManger = userManager;
            _iAppRole = iAppRole;
        }
        readonly UserManager<AppUser> _uManger;
        readonly IAppRoleRepository _iAppRole;
        public async Task<IdentityResult> AddUserAsync(AppUser user)
        {
           IdentityResult result = await _uManger.CreateAsync(user,user.PasswordHash);
           return result;
        }

        public async Task AddToRoleAsync(AppUser appUser, string appRole)
        {
            await _uManger.AddToRoleAsync(appUser, appRole);
        }
    }
}
