using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Slot
{
    public int Id { get; set; }

    public int? PastorId { get; set; }

    public DateOnly? SlotDate { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public bool? IsAvailable { get; set; }

    public bool? IsClosed { get; set; }

    public virtual ICollection<Bookingevent> Bookingevents { get; set; } = new List<Bookingevent>();

    public virtual Pastor? Pastor { get; set; }
}
