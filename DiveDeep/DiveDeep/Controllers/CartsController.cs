using DiveDeep.Persistence;
using DiveDeep.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.Controllers
{
    public class CartsController : Controller
    {
        public IActionResult Index()
        {
            PackageEquipmentViewData viewData = new PackageEquipmentViewData();

            viewData.CartEquipments = CartRepository.GetBookings();

            return View(viewData);
        }
    }
}
