﻿using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VM.VMClasses
{
    public class AppUserVM
    {
        public int ID { get; set; }
  
        public string PasswordHash { get; set; }
      
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage ="Lutfen Email formatinda bir adress griniz")]
     
        public string Email { get; set; }
    
        public bool Agree { get; set; }
        public DataStatus Status { get; set; }
    }
}
