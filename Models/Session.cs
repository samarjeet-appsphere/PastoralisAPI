using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Session
{
    public int Id { get; set; }

    public int? EventId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? PlanId { get; set; }

    public bool? IsPaymentSuccessful { get; set; }

    public int? StatusId { get; set; }

    public virtual Bookingevent? Event { get; set; }

    public virtual Plan? Plan { get; set; }

    public virtual Sessionstatus? Status { get; set; }
}
