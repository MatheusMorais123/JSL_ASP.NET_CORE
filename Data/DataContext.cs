
using API.Models;
using Microsoft.EntityFrameworkCore;
namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Driver> driver {get; set;}
        public DbSet<Trip> trip {get; set;}
    }
}