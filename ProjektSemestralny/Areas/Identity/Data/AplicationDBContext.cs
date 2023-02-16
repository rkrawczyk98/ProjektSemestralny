using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjektSemestralny.Areas.Identity.Data;
using ProjektSemestralny.Models;
using System.Reflection.Emit;

namespace ProjektSemestralny.Areas.Identity.Data;

public class AplicationDBContext : IdentityDbContext<ApplicationUser>
{
    public AplicationDBContext(DbContextOptions<AplicationDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Survey_Question>().HasKey(sq => new
        {
            sq.SurveyId,
            sq.QuestionId
        });

        modelBuilder.Entity<Survey_Question>().HasOne(q => q.Question).WithMany(sq => sq.Surveys_Questions).HasForeignKey(q =>
        q.QuestionId);

        modelBuilder.Entity<Survey_Question>().HasOne(q => q.Survey).WithMany(sq => sq.Surveys_Questions).HasForeignKey(q =>
        q.SurveyId);

        base.OnModelCreating(modelBuilder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    private class ApplicationUserEntityConfiguration :
    IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(255);
            builder.Property(x => x.LastName).HasMaxLength(255);
        }
    }

    public DbSet<ProjektSemestralny.Models.Survey> Survey { get; set; }

    public DbSet<ProjektSemestralny.Models.Survey_Question> Survey_Question { get; set; }
    
    public DbSet<ProjektSemestralny.Models.Answer> Answer { get; set; }

    public DbSet<ProjektSemestralny.Models.Category> Category { get; set; }

    public DbSet<ProjektSemestralny.Models.Question> Question { get; set; }



}
