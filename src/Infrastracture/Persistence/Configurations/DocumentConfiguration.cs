using DocumentArchive.Domain.DocumentAggregator;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentArchive.Infrastructure.Persistence.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable(DocumentArchiveDbContextSchema.DocumentDbSchema.TableName);

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DocumentId.Create(value));

        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(512);

        builder.Property(p => p.Description)
            .IsRequired(false)
            .IsUnicode(true)
            .HasMaxLength(2048);


        builder.OwnsMany(p => p.CommentIds, cb =>
        {
            cb.ToTable(DocumentArchiveDbContextSchema.DocumentDbSchema.CommentIdsTableName);
        }).UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(p => p.CommentIds)
            .Metadata
            .SetField(DocumentArchiveDbContextSchema.DocumentDbSchema.CommentIdsBackField);


        builder.OwnsMany(p => p.Tags, cb =>
        {
            cb.ToTable(DocumentArchiveDbContextSchema.DocumentDbSchema.TagTableName);
            cb.Property(p => p.Value).IsRequired().HasMaxLength(128);

        }).UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(p => p.Tags)
            .Metadata
            .SetField(DocumentArchiveDbContextSchema.DocumentDbSchema.TagsBackField);



        builder.OwnsOne(x => x.CategoryId, cb =>
        {
            cb.Property(c => c.Value)
                .IsRequired()
                .HasColumnName(DocumentArchiveDbContextSchema.DocumentDbSchema.CategoryId);
        });


        builder.OwnsOne(x => x.CustomerId, cb =>
        {
            cb.Property(c => c.Value)
                .IsRequired()
                .HasColumnName(DocumentArchiveDbContextSchema.DocumentDbSchema.CustomerId);
        });


    }
}
