﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Options
{
    public class AppUserConfiguration : BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);
            builder.Ignore(x =>x.ID);
            builder.HasMany(x =>x.UserRoles).WithOne(x =>x.User).HasForeignKey(x =>x.UserId).IsRequired();
            builder.HasMany(x => x.Orders).WithOne(x => x.AppUser).HasForeignKey(x =>x.AppUserID);
            builder.HasOne(x => x.UserProfile).WithOne(x => x.AppUser).HasForeignKey<UserProfile>(x =>x.ID);


        }
    }
}
