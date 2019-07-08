using mentor_api.Models;
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
        public DbSet<Specialization> Specialization { get; set; }
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
            .WithMany(c => c.MentorCities)
            .HasForeignKey(mc => mc.CityId);

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