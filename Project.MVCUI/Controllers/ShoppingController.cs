using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using PagedList;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.ENTITIES.Models;
using Project.MVCUI.Models.PageVMs;
using Project.MVCUI.Models.SessionService;
using Project.MVCUI.Models.ShoppingTools;
using Project.VM.VMClasses;

namespace Project.MVCUI.Controllers
{
    public class ShoppingController : Controller
    {
        ICategoryManager _cManager;
        IProductManager _pManager;
        public ShoppingController( IProductManager pManager , ICategoryManager categoryManager)
        {
            _pManager = pManager;
            _cManager = categoryManager;
        }
        public async Task<IActionResult> Index(int? page, int? categoryID)
        {
            ShoppingPageVM shopping = new()
            {
                Categories = await ListCategories(),
                Products = categoryID == null ? ActiveProducts().ToPagedList(page ?? 1, 5) : ActiveProducts().Where(x => x.CategoryID == categoryID).ToPagedList(page ?? 1, 5),
                
            };
            return View(shopping);
        }
        private List<ProductVM> ActiveProducts()
        {
            List<ProductVM> products = _pManager.Select(x => new ProductVM
            {
                ID = x.ID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                ImagePath = x.ImagePath
                
            }).Where(x =>x.Status != ENTITIES.Enums.DataStatus.Deleted).ToList();
            return products;
        }
        private async Task<ICollection<CategoryVM>> ListCategories()
        {
            ICollection<CategoryVM> categories = await _cManager.Select(x => new CategoryVM
            {
                ID = x.ID,
                CategoryName = x.CategoryName

            }).ToListAsync();
            return categories;
        }
        Cart GetCartFromSession(string key)
        {
            return HttpContext.Session.GetObject<Cart>(key);  
        }
        void SetCartToSession(Cart c)
        {
            HttpContext.Session.SetObject("scart",c);
        }
        void ControlCart(Cart c)
        {
            if (c.CartItems.Count == 0) HttpContext.Session.Remove("scart");
        }
        public async Task<IActionResult> AddToCart(int id)
        {
            Product p = await _pManager.FindAsync(id);
            CartItem item = new()
            {
                ID = id,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                CategoryName = p.Category.CategoryName,
                ImagePath = p.ImagePath,
                CategoryID = p.CategoryID

            };
            Cart c = GetCartFromSession("scart") == null ? new Cart() : GetCartFromSession("scart");
            c.AddToCart(item);
            SetCartToSession(c);
            TempData["Message"] = $"{item.ProductName} isimli ürün sepete eklenmiştir";
            return RedirectToAction("Index");
        }
        public IActionResult DecreaseFromCart(int id)
        {
            if (GetCartFromSession("scart") != null)
            {
                Cart c = GetCartFromSession("scart");
                c.Decrease(id);
                SetCartToSession(c);
                ControlCart(c);
            }
            return RedirectToAction("CartPage");
        }
        public IActionResult CartPage()
        {
            if (GetCartFromSession("scart") == null)
            {
                TempData["Message"] = "Sepetiniz boş";
                return RedirectToAction("Index");
            }
            Cart c = GetCartFromSession("scart");
            return View(c);
        }
        public IActionResult DeleteCart(int id)
        {
            if (GetCartFromSession("scart") != null)
            {
                Cart c = GetCartFromSession("scart");
                c.RemoveFromCart(id);
                SetCartToSession(c);
                ControlCart(c);

            }
            return RedirectToAction("CartPage");
        }
    }
}
