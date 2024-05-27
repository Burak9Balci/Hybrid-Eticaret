using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Managers.Abstracts;
using Project.ENTITIES.Models;
using Project.MVCUI.Areas.Admin.Models.PageVMs.Product;
using Project.VM.VMClasses;

namespace Project.MVCUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ICategoryManager _cManager;
        IProductManager _productManager;
        public ProductController(IProductManager productManager,ICategoryManager categoryManager)
        {
            _cManager = categoryManager;
            _productManager = productManager;
        }
        public async Task<IActionResult> ListProducts()
        {
            ListProductPageVM listProductPageVM = new ListProductPageVM 
            {
              Products = await _productManager.Select(x => new ProductVM
              {
                  ID = x.ID,
                  ProductName = x.ProductName,
                  UnitPrice = x.UnitPrice,
                  UnitInStock = x.UnitInStock,
                  CategoryName = x.Category.CategoryName,
                  ImagePath = x.ImagePath,
                  Status = x.Status

              }).ToListAsync(),
            };
            return View(listProductPageVM);
        }
        public async Task<IActionResult> AddProduct()
        {
            ProductAddUpdatePageVM pAUPVM = new ProductAddUpdatePageVM
            {
                Categories =  await _cManager.Select(x => new CategoryVM
                {
                    ID =x.ID,
                    CategoryName = x.CategoryName,

                }).ToListAsync()
            };
            return View(pAUPVM);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductVM product)
        {
            Product p = new()
            {
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                Category = await _cManager.FindAsync(product.CategoryID),
                ImagePath = product.ImagePath ,

            };
            await _productManager.AddAsync(p);
            return RedirectToAction("ListProducts");
        }
        public async Task<IActionResult> UpdateProduct(int id)
        {
            ProductAddUpdatePageVM productPageVM = new ProductAddUpdatePageVM
            {
               Product = await _productManager.Select(x => new ProductVM
               {
                   ID = x.ID,
                   ProductName = x.ProductName,
                   UnitPrice = x.UnitPrice,
                   CategoryID = x.CategoryID,
                   ImagePath= x.ImagePath,

               }).FirstOrDefaultAsync(x =>x.ID == id),

               Categories = await _cManager.Select(x => new CategoryVM
               {
                   ID = x.ID,
                   CategoryName = x.CategoryName,

               }).ToListAsync()
            };
            return View(productPageVM);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductVM product)
        {
            Product p = await _productManager.FindAsync(product.ID);
            p.ProductName = product.ProductName;
            p.UnitPrice = product.UnitPrice;
            p.CategoryID = product.CategoryID;
            p.ImagePath = product.ImagePath;

            await _productManager.UpdateAsync(p);
            return RedirectToAction("ListProducts");
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            Product p = await _productManager.FindAsync(id);
            await _productManager.DeleteAsync(p);
            return RedirectToAction("ListProducts");
        }
    }
}
