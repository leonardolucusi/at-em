
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public class Context(DbContextOptions<Context> options) : DbContext(options){
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
