using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DiveDeep.Service;
namespace DiveDeep.Controllers
{
    public class CartsController : Controller
    {
        private readonly CartService _cartService;

        public CartsController(CartService cartService, IEquipmentRepository equipmentRepository, IPackageRepository packageRepository)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            List<CartItem> cartItems = _cartService.GetAll();

            return View(cartItems);
        }

        [HttpPost]
        public IActionResult Checkout()
        {
            _cartService.AssignProfileToAllCartItems(1);

            return RedirectToAction(nameof(Index));
        }
    }
}
