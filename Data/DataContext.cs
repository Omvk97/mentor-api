using mentor_api.Models;
using mentor_api.Models.Teachings;
using Microsoft.EntityFrameworkCore;

namespace mentor_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<TeachableCities> TeachableCities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Teaching> Teachings { get; set; }
        public DbSet<TeachingSpecialization> TeachingSpecializations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TeachableCities many to many relationship
            modelBuilder.Entity<TeachableCities>()
            .HasKey(mc => new { mc.MentorId, mc.CityId });
            modelBuilder.Entity<TeachableCities>()
            .HasOne(mc => mc.Mentor)
            .WithMany(m => m.TeachableCities)
            .HasForeignKey(mc => mc.MentorId);
            modelBuilder.Entity<TeachableCities>()
            .HasOne(mc => mc.City)
            .WithMany(c => c.TeachableCities)
            .HasForeignKey(mc => mc.CityId);

            modelBuilder.Entity<TeachingSpecialization>()
            .HasKey(ts => new { ts.SpecializationId, ts.TeachingId });
            modelBuilder.Entity<TeachingSpecialization>()
            .HasOne(ts => ts.Specialization)
            .WithMany(s => s.Teachings)
            .HasForeignKey(ts => ts.SpecializationId);
            modelBuilder.Entity<TeachingSpecialization>()
            .HasOne(ts => ts.Teaching)
            .WithMany(s => s.TeachingSpecializations)
            .HasForeignKey(ts => ts.TeachingId);

            // City unique postal code
            modelBuilder.Entity<City>()
            .HasAlternateKey(city => city.PostalCode);

            // Category unique name
            modelBuilder.Entity<Category>()
            .HasAlternateKey(category => category.Name);

            // Specialisation unique name
            modelBuilder.Entity<Specialization>()
            .HasAlternateKey(specia => specia.Name);
        }
    }
}