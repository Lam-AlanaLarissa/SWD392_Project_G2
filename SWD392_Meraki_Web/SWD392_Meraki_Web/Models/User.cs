using System;
using System.Collections.Generic;

namespace SWD392_Meraki_Web.Models;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public int? Gender { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public DateOnly? Birthday { get; set; }

    public int Role { get; set; }

    public int Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<CheckIn> CheckIns { get; set; } = new List<CheckIn>();

    public virtual ICollection<CourtManager> CourtManagers { get; set; } = new List<CourtManager>();

    public virtual ICollection<Court> Courts { get; set; } = new List<Court>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<WishList> WishLists { get; set; } = new List<WishList>();
}
