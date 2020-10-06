using Domain.Entities;
using Infrastructure.Seeds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Seeds
            builder.Entity<Country>().HasData(CountrySeed.GetCountries());
            builder.Entity<State>().HasData(StateSeed.GetStates());
            #endregion

            base.OnModelCreating(builder);
        }

        // Entities
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
    }
}
