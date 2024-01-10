using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Bookingevent
{
    public int Id { get; set; }

    public int? CounseleeId { get; set; }

    public bool? SurveyAttempted { get; set; }

    public DateTime? BookingDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? PastorId { get; set; }

    public int? BookingStatusId { get; set; }

    public int? SubscriptionId { get; set; }

    public bool? IsPaymentSuccessful { get; set; }

    public bool? IsBooked { get; set; }

    public int? SlotId { get; set; }

    public virtual Bookingstatus? BookingStatus { get; set; }

    public virtual Counselee? Counselee { get; set; }

    public virtual Pastor? Pastor { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    public virtual Slot? Slot { get; set; }

    public virtual Subscription? Subscription { get; set; }
}
