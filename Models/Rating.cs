using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Rating
{
    public int Id { get; set; }

    public int? PastorId { get; set; }

    public int? Rating1 { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Pastor? Pastor { get; set; }
}
