using DocumentArchive.Domain.CommentAggregator;

namespace DocumentArchive.APIs.Endpoints.Document.GetDocuments
{
    public record GetDocumentsResponse(Guid DocumentId,
        int UserId,
        Guid CategoryId,
        Guid CustomerId,
        string Title,
        string Description,
        DateTime CreatedOnUtc,
        DateTime? ApprovedOnUtc,
        DocumentStatus Status,
        string[] Tags);
    
}
