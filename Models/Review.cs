using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Review
{
    public int Id { get; set; }

    public int? ReviewedBy { get; set; }

    public string? ReviewComment { get; set; }

    public int? PastorId { get; set; }

    public int? Rating { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Pastor? Pastor { get; set; }

    public virtual User? ReviewedByNavigation { get; set; }
}
