using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Userimage
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Name { get; set; }

    public byte[]? Image { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual User? User { get; set; }
}
