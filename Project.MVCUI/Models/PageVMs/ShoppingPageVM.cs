using PagedList;
using Project.ENTITIES.Models;
using Project.VM.VMClasses;

namespace Project.MVCUI.Models.PageVMs
{
    public class ShoppingPageVM
    {
        public ICollection<CategoryVM> Categories { get; set; }
        public IPagedList<ProductVM> Products { get; set; }
    }
}
