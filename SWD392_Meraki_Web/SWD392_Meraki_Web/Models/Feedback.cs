using System;
using System.Collections.Generic;

namespace SWD392_Meraki_Web.Models;

public partial class Feedback
{
    public string FeedbackId { get; set; } = null!;

    public string CourtId { get; set; } = null!;

    public string Content { get; set; } = null!;

    public double Rate { get; set; }

    public long? Attachment { get; set; }

    public DateOnly CreateAt { get; set; }

    public string CreateBy { get; set; } = null!;

    public virtual Court Court { get; set; } = null!;

    public virtual User CreateByNavigation { get; set; } = null!;
}
