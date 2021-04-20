using Microsoft.EntityFrameworkCore;
using RazorMvc.Models;

namespace RazorMvc.Data
{
    public class InternDbContext : DbContext
    {
        public InternDbContext(DbContextOptions<InternDbContext> options)
            : base(options)
        {
        }

        public DbSet<Intern> Interns { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Intern>()
              .HasOne(_ => _.Location)
              .WithMany(_ => _.LocalInterns)
              .HasForeignKey("LocationId")
              .IsRequired();
        }
    }
}
