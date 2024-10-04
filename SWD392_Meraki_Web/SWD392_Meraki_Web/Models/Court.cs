using System;
using System.Collections.Generic;

namespace SWD392_Meraki_Web.Models;

public partial class Court
{
    public string CourtId { get; set; } = null!;

    public string CourtName { get; set; } = null!;

    public string Location { get; set; } = null!;

    public TimeOnly OpeningHours { get; set; }

    public TimeOnly ClosingHours { get; set; }

    public int Status { get; set; }

    public bool IsUsing { get; set; }

    public DateOnly CreateAt { get; set; }

    public string CreateBy { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual User CreateByNavigation { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<Revenue> Revenues { get; set; } = new List<Revenue>();

    public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();

    public virtual ICollection<WishList> WishLists { get; set; } = new List<WishList>();
}
