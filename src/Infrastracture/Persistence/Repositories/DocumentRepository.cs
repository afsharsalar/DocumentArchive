using DocumentArchive.Domain.DocumentAggregator;

using Microsoft.EntityFrameworkCore;

using System.Collections.Immutable;

namespace DocumentArchive.Infrastructure.Persistence.Repositories;

public class DocumentRepository(DocumentArchiveDbContext dbContext) : IDocumentRepository
{
   
    public void Create(Document document)
    {
        dbContext.Documents.Add(document);
    }

    public void Delete(Document document)
    {
        throw new NotImplementedException();
    }

    public Task<Document?> GetById(DocumentId documentId, CancellationToken cancellationToken)
    {
        return dbContext.Documents.SingleOrDefaultAsync(p => p.Id == documentId, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Document>> GetPaged(int page, int pageSize, CancellationToken cancellationToken)
    {
        var documents = await dbContext.Documents
                                      .Skip((page - 1) * pageSize).Take(pageSize)
                                      .ToListAsync(cancellationToken);

        return [.. documents];
    }

    public Task<IReadOnlyCollection<Tag>> GetTagsAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }    
}
