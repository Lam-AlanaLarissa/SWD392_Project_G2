using System;
using System.Collections.Generic;

namespace SWD392_Meraki_Web.Models;

public partial class Revenue
{
    public string RevenueId { get; set; } = null!;

    public string CourtId { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public double Total { get; set; }

    public virtual Court Court { get; set; } = null!;

    public virtual ICollection<RevenueDetail> RevenueDetails { get; set; } = new List<RevenueDetail>();
}
