using System.Reflection;
using Domain.Customer;
using Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public class Context(DbContextOptions<Context> options) : DbContext(options){
        public DbSet<Product> Products { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Complement> Complements { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
