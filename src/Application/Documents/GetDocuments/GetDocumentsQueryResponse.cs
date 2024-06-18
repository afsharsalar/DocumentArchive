namespace DocumentArchive.Application.Documents.GetDocuments
{
    public record GetDocumentsQueryResponse (
        DocumentId DocumentId,
        CategoryId? CategoryId,
        CustomerId? CustomerId,
        int UserId,
        string Title,
        string Description,
        DateTime CreatedOnUtc)
    {
        public static explicit operator GetDocumentsQueryResponse(Document document)
            => new GetDocumentsQueryResponse
            (
                document.Id, 
                document.CategoryId, 
                document.CustomerId,
                document.UserId,
                document.Title,
                document.Description,
                document.CreatedOnUtc);
    }
}
