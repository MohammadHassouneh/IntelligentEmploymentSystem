using System;
using System.Collections.Generic;

namespace IntelligentEmploymentSystem.DBEntities;

public partial class Resume
{
    public int ResumeId { get; set; }

    public string Name { get; set; } = null!;

    public string Experience { get; set; } = null!;

    public string Education { get; set; } = null!;

    public string Skills { get; set; } = null!;

    public string Summary { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? PicPath { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();

    public virtual User User { get; set; } = null!;
}
