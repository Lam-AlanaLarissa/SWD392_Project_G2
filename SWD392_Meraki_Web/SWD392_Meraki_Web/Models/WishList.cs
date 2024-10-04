using System;
using System.Collections.Generic;

namespace SWD392_Meraki_Web.Models;

public partial class WishList
{
    public long WishId { get; set; }

    public string CourtId { get; set; } = null!;

    public string AddBy { get; set; } = null!;

    public virtual User AddByNavigation { get; set; } = null!;

    public virtual Court Court { get; set; } = null!;
}
