namespace SWD392_Meraki_Web.Models
{
    public class CartItem
    {
        public Slot Slot { get; set; } = null!;
        public int Quantity { get; set; }
    }

    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public double TotalPrice => Items.Sum(i => i.Slot.SlotPrice * i.Quantity);
    }

}