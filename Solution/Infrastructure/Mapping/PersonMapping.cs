using Domain.Customer;
using Infrastructure.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

public class PersonMapping : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable(DbHelper.TablePerson, DbHelper.SchemaCustomer);
        
        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Cpf)
            .HasMaxLength(11);
        
        builder.Property(x => x.Rg)
            .HasMaxLength(11);
    }
}
