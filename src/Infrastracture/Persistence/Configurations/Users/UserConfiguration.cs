using DocumentArchive.Domain.UserAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentArchive.Infrastructure.Persistence.Configurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.ToTable(DocumentArchiveDbContextSchema.UserDbSchema.TableName);

        builder.HasKey(t => t.Id);
        builder.Property(p => p.UserName).IsRequired().HasMaxLength(256);
        builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(11);

    }
}
