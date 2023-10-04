using CDS_Hooks.Models;
using Microsoft.EntityFrameworkCore;

namespace CDS_Hooks.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Services> Services { get; set; }
        public DbSet<Prefetch> Prefetch { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prefetch>().HasNoKey();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Services>()
                .HasOne(s => s.Prefetch)  // Define the navigation property
                .WithOne()                // One-to-one relationship
                .HasForeignKey<Prefetch>(p => p.ServicesId); // Foreign key

            // Ignore the 'Prefetch' property in the 'Services' class
            modelBuilder.Entity<Services>()
                .Ignore(s => s.Prefetch);
        }*/

    }
}
