using Microsoft.EntityFrameworkCore;
using ProjektSemestralny.Models;

namespace ProjektSemestralny.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        public DbSet<Ankiety> Ankiety { get; set; }
    }
}
