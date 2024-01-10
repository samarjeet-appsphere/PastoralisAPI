using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class AuditLog
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? EventType { get; set; }

    public string? EventName { get; set; }

    public string? EventDescription { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? EventId { get; set; }

    public virtual Userentityaccess? Event { get; set; }
}
