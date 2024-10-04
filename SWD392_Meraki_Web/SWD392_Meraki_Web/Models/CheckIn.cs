using System;
using System.Collections.Generic;

namespace SWD392_Meraki_Web.Models;

public partial class CheckIn
{
    public string BookingId { get; set; } = null!;

    public DateTime CheckInTime { get; set; }

    public bool IsChecked { get; set; }

    public string? CheckedBy { get; set; }

    public bool? IsCheckedOut { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual User? CheckedByNavigation { get; set; }
}
