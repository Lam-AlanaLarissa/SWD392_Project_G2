namespace SWD392_Meraki_Web.Models
{
    public class CartItem
    {
        public string CourtName { get; set; }
        public Slot slotInCart { get; set; }
    }
    public class Cart
    {
        List<CartItem> cartItems = new List<CartItem>();
        List<Court> courts = new List<Court>(); 
        
        public IEnumerable<CartItem> CartItems 
        { 
            get { return cartItems; } 
        }
        public void Add(Slot slot)
        { 
            string courtId = slot.CourtId;
            var item = cartItems.FirstOrDefault(i => i.slotInCart.SlotId == slot.SlotId);
            var courtName = courts.FirstOrDefault(c => c.CourtId.Equals(courtId)).CourtName;

            if (item == null)
            {
                cartItems.Add(new CartItem
                {
                    CourtName = courtName,
                    slotInCart = slot,
                });
            }
        }
        public void ChangeSlot(Slot slot)
        {

        }
        public void Remove(Slot slot)
        {
            var item = cartItems.FirstOrDefault(c => c.slotInCart.SlotId == slot.SlotId);

            if (item == null)
            {
                cartItems.Remove(item);
            }
        }
    }
}
