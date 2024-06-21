
namespace DocumentArchive.APIs.Endpoints.Document.CreateDocument
{
    public record CreateDocumentRequest(
        Guid CategoryId,
        Guid CustomerId,
        int UserId,
        string Title,
        string Description,
        string[] Tags
    );
}
