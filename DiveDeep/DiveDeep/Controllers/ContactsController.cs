using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
