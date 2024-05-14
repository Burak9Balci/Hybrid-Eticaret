﻿using Microsoft.AspNetCore.Identity;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class AppUserRole : IdentityUserRole<int>, IEntity
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
        public AppUserRole()
        {
            Status = DataStatus.Inserted;
            CreatedDate = DateTime.Now;
        }

        //Rs

        public virtual AppUser User { get; set; }
        public virtual AppRole Role { get; set; }
    }
}
