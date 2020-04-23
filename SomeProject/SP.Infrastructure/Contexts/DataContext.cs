using Microsoft.EntityFrameworkCore;
using SP.Domain.Entities;
using static SP.Application.Connection.ConnectionString;

namespace SP.Infrastructure.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(CurrentConnectionString);

        // Entities
        public DbSet<CheckingAccount> CheckingAccounts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<State> States { get; set; }
    }
}
