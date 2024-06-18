using DocumentArchive.Domain.UserAggregator;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentArchive.Infrastructure.Persistence.Configurations.Users;

public class UserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<int>>
{
    public void Configure(EntityTypeBuilder<IdentityUserToken<int>> builder)
    {
        builder.ToTable(DocumentArchiveDbContextSchema.UserTokenDbSchema.TableName);
        builder.HasKey(p => p.UserId);
    }
}
