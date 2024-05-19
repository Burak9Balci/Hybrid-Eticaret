using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class CategoryManager : BaseManager<Category>,ICategoryManager
    {
        ICategoryRepository _iRep;
        public CategoryManager(ICategoryRepository iRep) : base(iRep)
        {
            _iRep = iRep;
        }
    }
}
