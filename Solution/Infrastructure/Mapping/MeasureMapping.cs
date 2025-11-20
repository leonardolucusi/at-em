using Domain.Product;
using Infrastructure.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class MeasureMapping : IEntityTypeConfiguration<Measure>
    {
        public void Configure(EntityTypeBuilder<Measure> builder)
        {
            builder.ToTable(DbHelper.TableMeasure, DbHelper.SchemaProduct)
                .HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            builder.Property(x => x.Height)
                .IsRequired();

            builder.Property(x => x.Width)
                .IsRequired();
            
            builder.Property(x => x.Depth)
                .IsRequired();
            
            builder.Property(x => x.Weight)
                .IsRequired();
            
            builder.HasOne(x => x.Product)
                .WithMany(x => x.Measures)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
