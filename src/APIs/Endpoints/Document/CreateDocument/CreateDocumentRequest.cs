
namespace DocumentArchive.APIs.Endpoints.Document.CreateDocument
{
    public record CreateDocumentRequest(
        Guid CategoryId,
        Guid CustomerId,
        string Title,
        string Description,
        string[] Tags
    );
}
