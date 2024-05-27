using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VM.VMClasses
{
    public class AppRoleVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DataStatus Status { get; set; }
    }
}
