using System;
using System.Collections.Generic;

namespace SWD392_Meraki_Web.Models;

public partial class CardProvider
{
    public string CardProviderName { get; set; } = null!;

    public string? CpfullName { get; set; }

    public virtual ICollection<CourtManager> CourtManagers { get; set; } = new List<CourtManager>();
}
