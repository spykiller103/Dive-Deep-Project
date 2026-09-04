using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
