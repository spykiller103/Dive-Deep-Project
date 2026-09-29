using DiveDeep.Service;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.Controllers
{
    public class DivingConditionsController : Controller
    {
        private readonly DivingConditionsHttpService _openMeteoService;

        public DivingConditionsController( DivingConditionsHttpService openMeteoService)
        {
            _openMeteoService = openMeteoService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
