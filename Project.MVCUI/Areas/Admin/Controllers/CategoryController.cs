using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using Project.MVCUI.Areas.Admin.Models.PageVMs.Category;
using Project.VM.VMClasses;

namespace Project.MVCUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryRepository _iCat;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _iCat = categoryRepository;
        }
        public async Task<IActionResult> ListCategories()
        {
            ListCategoryPageVM lstCatPageVM = new ListCategoryPageVM
            {
                Categories = await _iCat.Select(x => new CategoryVM
                {
                    ID = x.ID,
                    CategoryName = x.CategoryName,
                    Description = x.Description,


                }).ToListAsync()
            };
            return View(lstCatPageVM);
        }
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryVM category)
        {
            Category c = new()
            {
                CategoryName = category.CategoryName,
                Description = category.Description

            };
            await _iCat.AddAsync(c);
            return RedirectToAction("ListCategories");
        }
        public async Task<IActionResult> UpdateCategory(int id)
        {
            CategoryAddUpdatePageVM aUPVM = new CategoryAddUpdatePageVM
            {
                Category = _iCat.Select(x => new CategoryVM
                {
                    ID = x.ID,
                    CategoryName = x.CategoryName,
                    Description = x.Description

                }).FirstOrDefault(x =>x.ID == id),
            };
            return View(aUPVM);
         
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryVM category)
        {
            Category c = await _iCat.FindAsync(category.ID);
            c.Description = category.Description;
            c.CategoryName = category.CategoryName;
            await _iCat.UpdateAsync(c);
            return RedirectToAction("ListCategories");
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            Category c = await _iCat.FindAsync(id);
            await _iCat.DeleteAsync(c);
            return RedirectToAction("ListCategories");
        }
    }
}
