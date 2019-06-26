using mentor_api.Models;
using Microsoft.EntityFrameworkCore;

namespace mentor_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<User> Users { get; set; }

    }
}