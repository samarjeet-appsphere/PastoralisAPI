using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Bookingstatus
{
    public int Id { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Bookingevent> Bookingevents { get; set; } = new List<Bookingevent>();
}
