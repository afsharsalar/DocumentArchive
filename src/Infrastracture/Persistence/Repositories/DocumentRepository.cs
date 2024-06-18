using DocumentArchive.Domain.DocumentAggregator;

namespace DocumentArchive.Infrastructure.Persistence.Repositories;

public class DocumentRepository : IDocumentRepository
{
    public void Create(Document document)
    {
        throw new NotImplementedException();
    }

    public void Delete(Document document)
    {
        throw new NotImplementedException();
    }

    public Task<Document> GetById(DocumentId documentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public void Update(Document document)
    {
        throw new NotImplementedException();
    }
}
