using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Sessionstatus
{
    public int Id { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
