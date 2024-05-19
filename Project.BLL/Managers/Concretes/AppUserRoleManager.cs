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
    public class AppUserRoleManager : BaseManager<AppUserRole>,IAppUserRoleManager
    {
        IAppUserRoleRepository _iRep;
        public AppUserRoleManager(IAppUserRoleRepository iRep) : base(iRep)
        {
            _iRep = iRep;
        }
    }
}
