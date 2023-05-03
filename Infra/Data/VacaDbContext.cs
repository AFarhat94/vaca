using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class VacaDbContext : DbContext
    {
        public VacaDbContext(DbContextOptions<VacaDbContext> options)
        { }

        public DbSet<Place> Places { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Image> Images { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}