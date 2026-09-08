using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
