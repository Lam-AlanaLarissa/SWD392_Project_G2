using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SWD392_Meraki_Web.Models;

public partial class User
{
    public string UserId { get; set; } = null!;
    [Required(ErrorMessage = "Username là bắt buộc.")]
    public string Username { get; set; } = null!;
    [Required(ErrorMessage = "Email là bắt buộc.")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
    public string? Email { get; set; }

    public string Password { get; set; } = null!;
    [Required(ErrorMessage = "Giới tính là bắt buộc.")]
    public int? Gender { get; set; }
    [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
    public string? PhoneNumber { get; set; }
    [Required(ErrorMessage = "Địa chỉ là bắt buộc.")]
    public string? Address { get; set; }
    [Required(ErrorMessage = "Ngày sinh là bắt buộc.")]
    [DataType(DataType.Date)]
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
