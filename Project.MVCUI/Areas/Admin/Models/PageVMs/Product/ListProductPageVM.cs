using Project.VM.VMClasses;

namespace Project.MVCUI.Areas.Admin.Models.PageVMs.Product
{
    public class ListProductPageVM
    {
        public ICollection<ProductVM> Products { get; set; }
    }
}
