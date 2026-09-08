using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.Controllers
{
    public class ProfilesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
