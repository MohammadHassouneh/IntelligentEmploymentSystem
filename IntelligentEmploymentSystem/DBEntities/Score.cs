using System;
using System.Collections.Generic;

namespace IntelligentEmploymentSystem.DBEntities;

public partial class Score
{
    public int ScoreId { get; set; }

    public int Score1 { get; set; }

    public int ResumeId { get; set; }

    public int JobDescriptionId { get; set; }

    public virtual JobDescription JobDescription { get; set; } = null!;

    public virtual Resume Resume { get; set; } = null!;
}
