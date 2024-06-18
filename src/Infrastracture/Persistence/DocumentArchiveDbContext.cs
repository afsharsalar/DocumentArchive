using DocumentArchive.Domain.CategoryAggregator;
using DocumentArchive.Domain.CommentAggregator;
using DocumentArchive.Domain.CustomerAggregator;
using DocumentArchive.Domain.DocumentAggregator;
using DocumentArchive.Domain.UserAggregator;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DocumentArchive.Infrastructure.Persistence
{
    public class DocumentArchiveDbContext : IdentityDbContext<User, Role, int>
    {
        public DocumentArchiveDbContext(DbContextOptions<DocumentArchiveDbContext> options) : base(options)
        {

        }

        public DbSet<Document> Documents => Set<Document>();

        public DbSet<Comment> Comments => Set<Comment>();

        public DbSet<Category> Categories => Set<Category>();

        public DbSet<Customer> Customers => Set<Customer>();

        public override DbSet<User>  Users => Set<User>();

        public override DbSet<Role> Roles => Set<Role>();

        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(DocumentArchiveDbContextSchema.DefaultSchema);

            var assembly = typeof(IAssemblyMarker).Assembly;
            builder.ApplyConfigurationsFromAssembly(assembly);

        }
    }
}
