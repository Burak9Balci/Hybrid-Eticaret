using Project.VM.VMClasses;

namespace Project.MVCUI.Areas.Admin.Models.PageVMs.Category
{
    public class ListCategoryPageVM
    {
        public ICollection<CategoryVM> Categories { get; set; }
    }
}
