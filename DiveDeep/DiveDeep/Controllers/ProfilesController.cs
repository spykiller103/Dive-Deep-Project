using DiveDeep.Models;
using DiveDeep.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.Controllers
{
    public class ProfilesController : Controller
    {
        public IActionResult Index()
        {
            Profile profile = ProfileRepository.GetById(1);

            return View(profile);
        }
    }
}
