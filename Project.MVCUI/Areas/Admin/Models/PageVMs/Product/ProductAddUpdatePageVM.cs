using Project.ENTITIES.Models;
using Project.VM.VMClasses;

namespace Project.MVCUI.Areas.Admin.Models.PageVMs.Product
{
    public class ProductAddUpdatePageVM
    {
        public ProductVM Product { get; set; }
        public ICollection<CategoryVM> Categories { get; set; }
    }
}
