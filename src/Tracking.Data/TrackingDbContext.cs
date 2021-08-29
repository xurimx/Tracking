using Microsoft.EntityFrameworkCore;
using Tracking.Data.Configurations;
using Tracking.Domain.Entities;

namespace Tracking.Data
{
    public class TrackingDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public TrackingDbContext(DbContextOptions options) :base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
