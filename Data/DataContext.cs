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
        public DbSet<MentorCity> MentorCities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<TeachingSpecialization> TeachingSpecializations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MentorCity>()
            .HasKey(mc => new { mc.MentorId, mc.CityId });
            modelBuilder.Entity<MentorCity>()
            .HasOne(mc => mc.Mentor)
            .WithMany(m => m.MentorCities)
            .HasForeignKey(mc => mc.MentorId);
            modelBuilder.Entity<MentorCity>()
            .HasOne(mc => mc.City)
            .WithMany(c => c.MentorCities)
            .HasForeignKey(mc => mc.CityId);
        }
    }
}