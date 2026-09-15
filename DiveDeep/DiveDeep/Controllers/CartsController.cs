using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.Controllers
{
    public class CartsController : Controller
    {
        public IActionResult Index()
        {

            List<CartItem> bookings = CartRepository.GetAll();

            return View(bookings);
        }
    }
}
