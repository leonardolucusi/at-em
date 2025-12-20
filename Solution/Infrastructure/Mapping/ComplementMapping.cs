using Domain.Customer;
using Infrastructure.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

public class ComplementMapping : IEntityTypeConfiguration<Complement>
{
    public void Configure(EntityTypeBuilder<Complement> builder)
    {
        builder.ToTable(DbHelper.TableComplement, DbHelper.SchemaCustomer)
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Address)
            .HasMaxLength(150);

        builder.Property(x => x.AddressComplement)
            .HasMaxLength(50);
            
        builder.Property(x => x.District)
            .HasMaxLength(50);

        builder.Property(x => x.Country)
            .HasMaxLength(50);

        builder.Property(x => x.State)
            .HasMaxLength(50);

        builder.Property(x => x.City)
            .HasMaxLength(50);

        builder.Property(x => x.FederalUnit)
            .HasMaxLength(2);
        
        builder.Property(x => x.ZipCode)
            .HasMaxLength(8);
        
        builder.Property(x => x.Telephone)
            .HasMaxLength(15);
        
        builder.Property(x => x.Cellphone)
            .HasMaxLength(15);
        
        builder.Property(x => x.Email)
            .HasMaxLength(100);
        
        builder.Property(x => x.ContactName)
            .HasMaxLength(100);

        builder.Property(x => x.IsActive)
            .IsRequired();
            
        builder.HasOne(x => x.Person)
            .WithMany(x => x.Complements)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.Company)
            .WithMany(x => x.Complements)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}