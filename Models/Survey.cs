using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Survey
{
    public int Id { get; set; }

    public string? Question { get; set; }

    public string? Options { get; set; }

    public bool? IsActive { get; set; }

    public int? CounselingType { get; set; }

    public int? DisplayOrder { get; set; }

    public virtual Counsellingtype? CounselingTypeNavigation { get; set; }

    public virtual ICollection<Surveyresponse> Surveyresponses { get; set; } = new List<Surveyresponse>();
}
