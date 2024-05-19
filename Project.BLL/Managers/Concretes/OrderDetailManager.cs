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
    public class OrderDetailManager : BaseManager<OrderDetail>,IOrderDetailManager
    {
        IOrderDetailRepository _iRep;
        public OrderDetailManager(IOrderDetailRepository iRep) : base(iRep) 
        {
            _iRep = iRep;
        }
    }
}
