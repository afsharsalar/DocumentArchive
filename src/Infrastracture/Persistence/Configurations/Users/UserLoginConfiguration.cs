using DocumentArchive.Domain.UserAggregator;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentArchive.Infrastructure.Persistence.Configurations.Users;

public class UserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<int>>
{
   

    public void Configure(EntityTypeBuilder<Microsoft.AspNetCore.Identity.IdentityUserLogin<int>> builder)
    {
        builder.ToTable(DocumentArchiveDbContextSchema.UserLoginDbSchema.TableName);
        builder.HasKey(p => p.UserId);
    }
}
