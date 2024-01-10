using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Entitytype
{
    public int Id { get; set; }

    public string? EntityType1 { get; set; }

    public virtual ICollection<Userentityaccess> Userentityaccesses { get; set; } = new List<Userentityaccess>();
}
