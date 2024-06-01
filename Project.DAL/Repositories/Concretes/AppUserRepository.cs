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
        MyContext _db;
        IAppUserRepository _userRepository;
        public AppUserRepository(MyContext db, UserManager<AppUser> userManager, IAppUserRepository userRepository ) : base(db)
        {
          
            _db = db;
            _userRepository = userRepository;
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
            
            appUser.UserRoles = new List<AppUserRole>
            {
                new AppUserRole
                {
                    User = appUser,
                    Role = appRole
                }
            }; 
            await SaveAsync();
        }

        public async Task<bool> CheckPasswordAsync(AppUser appUser, string password)
        {
           // bool result = await _userRepository.AnyAsync(x =>x.UserName.Contains(appUser.UserName) && x.PasswordHash.Contains(appUser.PasswordHash));
            bool result = await _uManger.CheckPasswordAsync(appUser, password);;
            return result;
          
        }

        public async Task<IList<string>> GetRolesAsync(AppUser appUser)
        {
            List<string> roles = new List<string>();
            foreach (AppUserRole item in appUser.UserRoles)
            {
                string role = item.Role.Name;
                roles.Add(role);

            }
            //IList<string> roles = await _uManger.GetRolesAsync(appUser);
            return roles;
        }
    }
}
