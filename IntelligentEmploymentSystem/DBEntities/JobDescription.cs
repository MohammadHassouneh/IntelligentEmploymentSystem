using System;
using System.Collections.Generic;

namespace IntelligentEmploymentSystem.DBEntities;

public partial class JobDescription
{
    public int JobDescriptionId { get; set; }

    public string JobTitle { get; set; } = null!;

    public string JobBrief { get; set; } = null!;

    public string Responsibilities { get; set; } = null!;

    public string Requirements { get; set; } = null!;

    public int CompanyId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
}
