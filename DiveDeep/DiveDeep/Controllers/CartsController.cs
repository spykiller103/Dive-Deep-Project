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
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IPackageRepository _packageRepository;

        public CartsController(CartService cartService, IEquipmentRepository equipmentRepository, IPackageRepository packageRepository)
        {
            _cartService = cartService;
            _equipmentRepository = equipmentRepository;
            _packageRepository = packageRepository;
        }

        public IActionResult Index()
        {

            List<CartItem> bookings = _cartService.GetAll();

            return View(bookings);
        }
    }
}
