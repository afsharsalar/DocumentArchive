using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DocumentArchive.Infrastructure.Persistence;

public class DocumentArchiveDbContextFactory : IDesignTimeDbContextFactory<DocumentArchiveDbContext>
{
    public DocumentArchiveDbContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<DocumentArchiveDbContext>();
        optionBuilder.UseSqlServer("data source=.\\SQL2019;initial catalog=DocumentArchive;TrustServerCertificate=True;Trusted_Connection=True;");

        return new DocumentArchiveDbContext(optionBuilder.Options);
    }
}
