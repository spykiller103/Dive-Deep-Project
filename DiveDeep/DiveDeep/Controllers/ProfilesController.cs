using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DiveDeep.Service;
namespace DiveDeep.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly IProfileRepository _profileRepository;
        private readonly CartService _cartService;

        public ProfilesController(IProfileRepository profileRepository, CartService cartService)
        {
            _profileRepository = profileRepository;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            Profile profile = _profileRepository.GetById(0);
            List<CartItem>? cartItems = _cartService.GetAll();

            ProfileCartItemViewData vm = new ProfileCartItemViewData
            {
                Profile = profile,
                CartItems = cartItems
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
