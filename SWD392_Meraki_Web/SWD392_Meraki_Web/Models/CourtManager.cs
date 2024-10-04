using System;
using System.Collections.Generic;

namespace SWD392_Meraki_Web.Models;

public partial class CourtManager
{
    public string ManagerId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string? CardName { get; set; }

    public string? CardNumber { get; set; }

    public string? CardProviderName { get; set; }

    public virtual CardProvider? CardProviderNameNavigation { get; set; }

    public virtual User User { get; set; } = null!;
}
