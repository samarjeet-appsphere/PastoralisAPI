using System;
using System.Collections.Generic;

namespace Pastorials.Models;

public partial class Surveyresponse
{
    public int Id { get; set; }

    public int? CounseleeId { get; set; }

    public int? QuestionId { get; set; }

    public string? Response { get; set; }

    public int? CounselingType { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Counselee? Counselee { get; set; }

    public virtual Counsellingtype? CounselingTypeNavigation { get; set; }

    public virtual Survey? Question { get; set; }
}
