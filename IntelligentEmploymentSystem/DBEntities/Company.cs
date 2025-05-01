using System;
using System.Collections.Generic;

namespace IntelligentEmploymentSystem.DBEntities;

public partial class Company
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string AboutUs { get; set; } = null!;

    public string OurService { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string WebSite { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<JobDescription> JobDescriptions { get; set; } = new List<JobDescription>();
}
