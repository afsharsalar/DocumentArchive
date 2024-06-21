namespace DocumentArchive.APIs.Endpoints.Document.UpdateDocument
{
    public record UpdateDocumentRequest(
        Guid DocumentId, 
        Guid CategoryId,
        Guid CustomerId,
        int UserId,
        string Title,
        string Description,
        string[] Tags);
    
}
