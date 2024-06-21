using DocumentArchive.Domain.CommentAggregator;

namespace DocumentArchive.APIs.Endpoints.Document.GetDocument
{
    public record GetDocumentResponse
        (Guid Id,
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
