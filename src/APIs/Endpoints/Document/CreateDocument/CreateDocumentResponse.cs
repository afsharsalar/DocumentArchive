using DocumentArchive.Domain.CategoryAggregator;
using DocumentArchive.Domain.CustomerAggregator;
using DocumentArchive.Domain.DocumentAggregator;

namespace DocumentArchive.APIs.Endpoints.Document.CreateDocument
{
    public record CreateDocumentResponse  (Guid DocumentId);
}
