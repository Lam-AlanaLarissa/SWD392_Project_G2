using System;
using System.Collections.Generic;

namespace SWD392_Meraki_Web.Models;

public partial class Report
{
    public string ReportId { get; set; } = null!;

    public string Issue { get; set; } = null!;

    public string? Content { get; set; }

    public string? Attachment { get; set; }

    public DateOnly CreateAt { get; set; }

    public string CreateBy { get; set; } = null!;

    public string CourtId { get; set; } = null!;

    public virtual Court Court { get; set; } = null!;
}
