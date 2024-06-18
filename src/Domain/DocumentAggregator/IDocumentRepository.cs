namespace DocumentArchive.Domain.DocumentAggregator;

public interface IDocumentRepository
{

    Task<IReadOnlyCollection<Tag>> GetTagsAsync(CancellationToken cancellationToken);

    Task<Document> GetById(DocumentId documentId,CancellationToken cancellationToken);

    Task<IReadOnlyCollection<Document>> GetPaged(int page,int pageSize, CancellationToken cancellationToken);

    void Create(Document document);

    void Update(Document document);

    void Delete(Document document);


    Task SaveChangesAsync(CancellationToken cancellationToken);
}
