using DocumentArchive.Domain.DocumentAggregator;

using Microsoft.EntityFrameworkCore;

namespace DocumentArchive.Infrastructure.Persistence.Repositories;

public class DocumentRepository(DocumentArchiveDbContext context) : IDocumentRepository
{
    private readonly DocumentArchiveDbContext _context = context;
    public void Create(Document document)
    {
        _context.Documents.Add(document);
    }

    public void Delete(Document document)
    {
        throw new NotImplementedException();
    }

    public Task<Document?> GetById(DocumentId documentId, CancellationToken cancellationToken)
    {
        return _context.Documents.SingleOrDefaultAsync(p => p.Id == documentId, cancellationToken);
    }

    public Task<IReadOnlyCollection<Document>> GetPaged(int page, int pageSize, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<Tag>> GetTagsAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public void Update(Document document)
    {
        throw new NotImplementedException();
    }
}
