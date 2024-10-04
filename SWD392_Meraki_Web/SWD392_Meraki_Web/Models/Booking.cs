using System;
using System.Collections.Generic;

namespace SWD392_Meraki_Web.Models;

public partial class Booking
{
    public string BookingId { get; set; } = null!;

    public string CourtId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string? TypeId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int TotalSlot { get; set; }

    public string? DateOfWeek { get; set; }

    public bool IsOnline { get; set; }

    public int PaymentStatus { get; set; }

    public DateOnly CreateAt { get; set; }

    public virtual CheckIn? CheckIn { get; set; }

    public virtual Court Court { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual BookingType? Type { get; set; }

    public virtual User User { get; set; } = null!;
}
