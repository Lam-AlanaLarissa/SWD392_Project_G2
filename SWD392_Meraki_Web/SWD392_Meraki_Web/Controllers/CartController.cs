using Microsoft.AspNetCore.Mvc;
using SWD392_Meraki_Web.DatabaseConnection;
using SWD392_Meraki_Web.Models;
using SWD392_Meraki_Web.Services;

namespace SWD392_Meraki_Web.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        private readonly BookingBadmintonContext _context;

        public CartController(CartService cartService, BookingBadmintonContext context)
        {
            _cartService = cartService;
            _context = context;
        }

        public IActionResult Index()
        {
            // Get the cart from session
            var cart = _cartService.GetCart();
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(string slotId, int quantity)
        {
            var slot = _context.Slots.FirstOrDefault(s => s.SlotId == slotId);
            if (slot != null)
            {
                var cart = _cartService.GetCart();

                var cartItem = cart.Items.FirstOrDefault(i => i.Slot.SlotId == slotId);
                if (cartItem == null)
                {
                    cart.Items.Add(new CartItem { Slot = slot, Quantity = quantity });
                }
                else
                {
                    cartItem.Quantity += quantity;
                }

                _cartService.SaveCart(cart);
            }

            return RedirectToAction("Index");
        }
    }
}
