using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IntelligentEmploymentSystem.DBEntities;

public partial class IntelligentEmploymentSystemContext : DbContext
{
    public IntelligentEmploymentSystemContext()
    {
    }

    public IntelligentEmploymentSystemContext(DbContextOptions<IntelligentEmploymentSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<JobDescription> JobDescriptions { get; set; }

    public virtual DbSet<Resume> Resumes { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MOHAMMAD-PC;Database=IntelligentEmploymentSystem;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.CompanyId).HasColumnName("companyId");
            entity.Property(e => e.AboutUs)
                .HasMaxLength(500)
                .HasColumnName("aboutUs");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .HasColumnName("companyName");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.OurService)
                .HasMaxLength(500)
                .HasColumnName("ourService");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.WebSite)
                .HasMaxLength(200)
                .HasColumnName("webSite");
        });

        modelBuilder.Entity<JobDescription>(entity =>
        {
            entity.ToTable("JobDescription");

            entity.Property(e => e.JobDescriptionId).HasColumnName("jobDescriptionId");
            entity.Property(e => e.CompanyId).HasColumnName("companyId");
            entity.Property(e => e.JobBrief)
                .HasMaxLength(500)
                .HasColumnName("jobBrief");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .HasColumnName("jobTitle");
            entity.Property(e => e.Requirements)
                .HasMaxLength(500)
                .HasColumnName("requirements");
            entity.Property(e => e.Responsibilities)
                .HasMaxLength(500)
                .HasColumnName("responsibilities");

            entity.HasOne(d => d.Company).WithMany(p => p.JobDescriptions)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobDescription_Company");
        });

        modelBuilder.Entity<Resume>(entity =>
        {
            entity.ToTable("Resume");

            entity.Property(e => e.ResumeId).HasColumnName("resumeId");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.Education)
                .HasMaxLength(500)
                .HasColumnName("education");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Experience)
                .HasMaxLength(500)
                .HasColumnName("experience");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.PicPath)
                .HasMaxLength(500)
                .HasColumnName("picPath");
            entity.Property(e => e.Skills)
                .HasMaxLength(500)
                .HasColumnName("skills");
            entity.Property(e => e.Summary)
                .HasMaxLength(500)
                .HasColumnName("summary");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Resumes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resume_User1");
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.ToTable("Score");

            entity.Property(e => e.ScoreId).HasColumnName("scoreId");
            entity.Property(e => e.JobDescriptionId).HasColumnName("jobDescriptionId");
            entity.Property(e => e.ResumeId).HasColumnName("resumeId");
            entity.Property(e => e.Score1).HasColumnName("score");

            entity.HasOne(d => d.JobDescription).WithMany(p => p.Scores)
                .HasForeignKey(d => d.JobDescriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Score_JobDescription");

            entity.HasOne(d => d.Resume).WithMany(p => p.Scores)
                .HasForeignKey(d => d.ResumeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Score_Resume");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .HasColumnName("password");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
