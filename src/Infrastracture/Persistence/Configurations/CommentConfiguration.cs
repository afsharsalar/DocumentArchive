using DocumentArchive.Domain.CommentAggregator;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentArchive.Infrastructure.Persistence.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable(DocumentArchiveDbContextSchema.CommentDbSchema.TableName);

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => CommentId.Create(value));

        builder.Property(p => p.Content)
            .IsRequired()
            .HasMaxLength(512);



        builder.OwnsOne(x => x.DocumentId, cb =>
        {
            cb.Property(c => c.Value)
                .IsRequired()
                .HasColumnName(DocumentArchiveDbContextSchema.CommentDbSchema.DocumentId);
        });


        
    }
}
