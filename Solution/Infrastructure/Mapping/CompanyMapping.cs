using Domain.Customer;
using Infrastructure.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

public class CompanyMapping : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable(DbHelper.TableCompany, DbHelper.SchemaCustomer)
            .HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.CustomerType)
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();
        
        builder.Property(x => x.FantasyName)
            .HasMaxLength(120)
            .IsRequired();
        
        builder.Property(x => x.LegalName)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(x => x.Cnpj)
            .HasMaxLength(14)
            .IsRequired();

        builder.Property(x => x.StateRegistration)
            .HasMaxLength(14);

        builder.HasMany(x => x.Complements)
            .WithOne(x => x.Company)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}