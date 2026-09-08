using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.Controllers
{
    public class ProfilesController : Controller
    {
        public IActionResult Index()
        {
            Profile profile = ProfileRepository.GetById(1);

            ProfilePackageEquupmentViewData vm = new ProfilePackageEquupmentViewData
        {
                Profile = profile,
                Packages = new List<Package>(),
                Equipments = new List<Equipment>()
            };

            return View(vm);
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
