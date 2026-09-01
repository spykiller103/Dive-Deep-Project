using DiveDeep.Models;
using DiveDeep.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.Controllers
{
    public class PackagesController : Controller
    {
        public IActionResult Index()
        {
            List<Package> packeges = PackageRepository.GetAll();
            return View(packeges);
        }
    }
}
