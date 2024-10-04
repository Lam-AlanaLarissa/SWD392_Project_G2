using System;
using System.Collections.Generic;

namespace SWD392_Meraki_Web.Models;

public partial class RevenueDetail
{
    public string RdetailId { get; set; } = null!;

    public string RevenueId { get; set; } = null!;

    public DateOnly Date { get; set; }

    public double Income { get; set; }

    public virtual Revenue Revenue { get; set; } = null!;
}
