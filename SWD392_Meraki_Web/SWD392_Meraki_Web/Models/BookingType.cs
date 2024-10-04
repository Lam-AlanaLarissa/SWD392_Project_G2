using System;
using System.Collections.Generic;

namespace SWD392_Meraki_Web.Models;

public partial class BookingType
{
    public string TypeId { get; set; } = null!;

    public string TypeName { get; set; } = null!;

    public string? TypeDesc { get; set; }

    public int Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
