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

        [HttpPost]
        public IActionResult Rent(int id)
        {
            Package packagesToBeAdded = PackageRepository.GetById(id);

            CartRepository.AddPackage(packagesToBeAdded);

            return RedirectToAction(nameof(Index));
        }
    }
}
