using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
