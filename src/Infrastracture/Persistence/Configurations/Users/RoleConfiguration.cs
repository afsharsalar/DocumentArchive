using DocumentArchive.Domain.UserAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentArchive.Infrastructure.Persistence.Configurations.Users;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(DocumentArchiveDbContextSchema.RoleDbSchema.TableName);
        builder.HasKey(t => t.Id);
    }
}
