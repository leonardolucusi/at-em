using Domain.Customer;
using Domain.Utility;
using Infrastructure.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(DbHelper.TableCustomer, DbHelper.SchemaCustomer)
            .HasKey(x => x.Id);

        builder.Property(x => x.CustomerType)
            .HasConversion<string>()
            .HasMaxLength(20)
            .ValueGeneratedNever();

        builder.Property(x => x.CustomerType)
            .HasConversion<string>()
            .HasMaxLength(20);
        
        builder.HasOne(x => x.Complement)
            .WithOne(x => x.Customer)
            .HasForeignKey<Complement>(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}