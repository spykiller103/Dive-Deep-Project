using DiveDeep.Persistence;
using DiveDeep.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            PackageEquipmentViewData viewData = new PackageEquipmentViewData();

            viewData.CartEquipments = CartRepository.GetEquipment();
            viewData.CartPackages = CartRepository.GetPackages();

            return View(viewData);
        }
    }
}
