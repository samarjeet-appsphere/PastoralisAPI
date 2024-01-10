using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Counselee
{
    public int Id { get; set; }

    public bool? SurveyAttempted { get; set; }

    public string? SubscriptionType { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string CounseleeEmail { get; set; } = null!;

    public virtual ICollection<Blockreporthistory> Blockreporthistories { get; set; } = new List<Blockreporthistory>();

    public virtual ICollection<Bookingevent> Bookingevents { get; set; } = new List<Bookingevent>();

    public virtual ICollection<Surveyresponse> Surveyresponses { get; set; } = new List<Surveyresponse>();
}
