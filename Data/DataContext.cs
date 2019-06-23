using mentor_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace mentor_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Price> Prices { get; set; }

    }
}