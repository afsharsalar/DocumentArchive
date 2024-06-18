using DocumentArchive.Domain.CustomerAggregator;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentArchive.Infrastructure.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(DocumentArchiveDbContextSchema.CustomerDbSchema.TableName);

        builder.HasKey(p=>p.Id);
        
        builder.Property(x => x.Id)
              .ValueGeneratedNever()
              .HasConversion(
                   id => id.Value,
                   value => CustomerId.Create(value));


        builder.Property(p => p.Title)
            .IsRequired(true)
            .HasMaxLength(512);

        builder.OwnsOne(p => p.Address, ab =>
        {
            ab.Property(p => p.City)
                .IsRequired(false)
                .HasMaxLength(512)
                .HasColumnName(DocumentArchiveDbContextSchema.CustomerDbSchema.AddressCity);

            ab.Property(p => p.Street)
                .IsRequired(false)
                .HasMaxLength(1024)
                .HasColumnName(DocumentArchiveDbContextSchema.CustomerDbSchema.AddressStreet);

            ab.Property(p => p.PostalCode)
                .IsRequired(false)
                .HasMaxLength(10)
                .HasColumnName(DocumentArchiveDbContextSchema.CustomerDbSchema.AddressPostalCode);
        });
    }
}
