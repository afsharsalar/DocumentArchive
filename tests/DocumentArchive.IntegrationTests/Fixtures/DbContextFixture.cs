using DocumentArchive.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace DocumentArchive.IntegrationTests.Fixtures
{

    public class DbContextFixture : EfDatabaseBaseFixture<DocumentArchiveDbContext>
    {
        protected override DocumentArchiveDbContext BuildDbContext(DbContextOptions<DocumentArchiveDbContext> options)
        {
            return new DocumentArchiveDbContext(options);
        }
       
    }
}
