using fitness_tracker_serverside.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace fitness_tracker_serverside.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Measurement> Measurements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Exercise>()
                .HasOne(e => e.User)    // Define the navigation property
                .WithMany(u => u.Exercises)  // Define the reverse navigation property
                .HasForeignKey(e => e.UserId)  // Define the foreign key
                .IsRequired(); // Optionally, specify if the relationship is required

            modelBuilder.Entity<Measurement>()
                .HasOne(m => m.User)
                .WithMany(u => u.Measurements)
                .HasForeignKey(m => m.UserId);
        }
    }
}
