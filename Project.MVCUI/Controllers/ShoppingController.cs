using Microsoft.AspNetCore.Mvc;

namespace Project.MVCUI.Controllers
{
    public class ShoppingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
