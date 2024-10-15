using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SWD392_Meraki_Web.DatabaseConnection;
using SWD392_Meraki_Web.Models;

namespace SWD392_Meraki_Web.Controllers
{
    public class CartController : Controller
    {
        BookingBadmintonContext context = new BookingBadmintonContext();
        public Cart GetCart()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            Cart cart = null;

            if (!string.IsNullOrEmpty(cartJson))
            {
                cart = JsonConvert.DeserializeObject<Cart>(cartJson);  // Giải tuần tự hóa từ JSON
            }
            else
            {
                cart = new Cart();  // Nếu chưa có giỏ hàng, tạo mới
            }

            return cart;
        }

        public ActionResult AddToCart(string slotId)
        {
            var slot = context.Slots.SingleOrDefault(s => s.SlotId.Equals(slotId));

            if (slot == null)
            {
                GetCart().Add(slot);
            }
            return View();
        }
        public ActionResult ShowToCart()
        {
            var cart = GetCart();
            return View(cart);
        }
        public ActionResult ChangeSlotToCart()
        {
            return View();
        }
        public ActionResult RemoveFromCart(string slotId)
        {
            var slot = context.Slots.SingleOrDefault(s => s.SlotId.Equals(slotId));

            if (slot == null)
            {
                GetCart().Remove(slot);
            }
            return View();
        }
    }
}
