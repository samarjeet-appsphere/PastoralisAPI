using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Pastor
{
    public int Id { get; set; }

    public string? PastorDescription { get; set; }

    public TimeSpan? Duration { get; set; }

    public string PastorEmail { get; set; } = null!;

    public virtual ICollection<Blockreporthistory> Blockreporthistories { get; set; } = new List<Blockreporthistory>();

    public virtual ICollection<Bookingevent> Bookingevents { get; set; } = new List<Bookingevent>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();
}
