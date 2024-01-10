using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Blockreporthistory
{
    public int Id { get; set; }

    public int? CreatedBy { get; set; }

    public int? CounseleeId { get; set; }

    public int? PastorId { get; set; }

    public bool? IsBlocked { get; set; }

    public bool? IsReported { get; set; }

    public string? BlockReason { get; set; }

    public string? ReportReason { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Counselee? Counselee { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Pastor? Pastor { get; set; }
}
