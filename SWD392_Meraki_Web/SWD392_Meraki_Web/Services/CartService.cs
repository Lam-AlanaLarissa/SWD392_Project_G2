using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;
using SWD392_Meraki_Web.Models;

namespace SWD392_Meraki_Web.Services
{
    public class CartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string CartSessionKey = "Cart";

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Cart GetCart()
        {
            // Retrieve cart from session, or create a new one if it doesn't exist
            var cart = _httpContextAccessor.HttpContext.Session.GetObject<Cart>(CartSessionKey);
            return cart ?? new Cart();
        }

        public void SaveCart(Cart cart)
        {
            // Save the cart to session
            _httpContextAccessor.HttpContext.Session.SetObject(CartSessionKey, cart);
        }
    }



}
