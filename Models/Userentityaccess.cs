using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Userentityaccess
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? EntityId { get; set; }

    public int? EntityType { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual Entitytype? EntityTypeNavigation { get; set; }

    public virtual User? User { get; set; }
}
