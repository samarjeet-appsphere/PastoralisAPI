using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? UserEmail { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Password { get; set; }

    public int? EntityType { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public int? LoginAttempt { get; set; }

    public virtual ICollection<Blockreporthistory> Blockreporthistories { get; set; } = new List<Blockreporthistory>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Userentityaccess> Userentityaccesses { get; set; } = new List<Userentityaccess>();

    public virtual ICollection<Userimage> Userimages { get; set; } = new List<Userimage>();
}
