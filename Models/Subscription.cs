using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Subscription
{
    public int Id { get; set; }

    public string? SubscriptionPlan { get; set; }

    public decimal? SubscriptionPrice { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ICollection<Bookingevent> Bookingevents { get; set; } = new List<Bookingevent>();
}
