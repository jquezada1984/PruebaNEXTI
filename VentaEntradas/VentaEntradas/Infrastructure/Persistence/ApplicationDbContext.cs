using Microsoft.EntityFrameworkCore;
using VentaEntradas.Core.Domain.Entities;

namespace VentaEntradas.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Event>().HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
