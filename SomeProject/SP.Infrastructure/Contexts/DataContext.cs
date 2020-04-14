using Microsoft.EntityFrameworkCore;
using SP.Domain.Entities;
using static SP.Application.ConnectionString;

namespace SP.Infrastructure.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(CurrentConnectionString);

        // Entities
        public DbSet<Country> Countries { get; set; }
    }
}
