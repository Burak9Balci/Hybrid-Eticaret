﻿using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VM.VMClasses
{
    public class CategoryVM
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DataStatus Status { get; set; }

    }
}
