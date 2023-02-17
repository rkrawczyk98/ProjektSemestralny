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
    
    public DbSet<ProjektSemestralny.Models.Answer> Answer { get; set; }

    public DbSet<ProjektSemestralny.Models.Category> Category { get; set; }

    public DbSet<ProjektSemestralny.Models.Question> Question { get; set; }



}
