using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Plan
{
    public int Id { get; set; }

    public string? PlanType { get; set; }

    public DateTime? Plandate { get; set; }

    public string? PlanName { get; set; }

    public string? PlanCode { get; set; }

    public decimal? PlanPrice { get; set; }

    public bool? IsActive { get; set; }

    public int? PlanPeriod { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
