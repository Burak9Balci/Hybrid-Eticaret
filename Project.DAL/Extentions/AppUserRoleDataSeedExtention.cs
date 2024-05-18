using Microsoft.EntityFrameworkCore;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Extentions
{
    public static class AppUserRoleDataSeedExtention
    {
        public static void AppRoloSeed(ModelBuilder modelBuilder)
        {
            AppRole role1 = new()
            {
                Id = 1,
                Name = "Admin"
            };
            modelBuilder.Entity<AppRole>().HasData(role1);
            AppRole role2 = new()
            {
                Id = 2,
                Name = "Member"
            };
            modelBuilder.Entity<AppRole>().HasData(role2);
        }
    }
}
