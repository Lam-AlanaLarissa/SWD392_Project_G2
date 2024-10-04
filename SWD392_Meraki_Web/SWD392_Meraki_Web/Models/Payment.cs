using System;
using System.Collections.Generic;

namespace SWD392_Meraki_Web.Models;

public partial class Payment
{
    public string PaymentId { get; set; } = null!;

    public string BookingId { get; set; } = null!;

    public double TotalMoney { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public DateOnly PaymentDate { get; set; }

    public DateOnly CreateAt { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
