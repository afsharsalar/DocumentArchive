using DocumentArchive.Domain.CategoryAggregator;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentArchive.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.ToTable(DocumentArchiveDbContextSchema.CategoryDbSchema.TableName);

        builder.Property(p=>p.Title)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
            id => id.Value,
            value => CategoryId.Create(value)
            );
    }
}
