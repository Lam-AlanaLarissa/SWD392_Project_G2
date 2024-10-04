using System;
using System.Collections.Generic;

namespace SWD392_Meraki_Web.Models;

public partial class Slot
{
    public string SlotId { get; set; } = null!;

    public string CourtId { get; set; } = null!;

    public int SlotNumber { get; set; }

    public double SlotPrice { get; set; }

    public virtual Court Court { get; set; } = null!;
}
