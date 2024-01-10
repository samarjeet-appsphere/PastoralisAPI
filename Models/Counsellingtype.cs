using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Counsellingtype
{
    public int Id { get; set; }

    public string? CounsellingType1 { get; set; }

    public virtual ICollection<Surveyresponse> Surveyresponses { get; set; } = new List<Surveyresponse>();

    public virtual ICollection<Survey> Surveys { get; set; } = new List<Survey>();
}
