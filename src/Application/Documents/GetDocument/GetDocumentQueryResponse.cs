namespace DocumentArchive.Application.Documents.GetDocument
{
    public record GetDocumentQueryResponse(
        DocumentId DocumentId,
        CategoryId? CategoryId,
        CustomerId? CustomerId,
        int UserId,
        string Title,
        string Description,
        DateTime CreatedOnUtc,
        IReadOnlyCollection<Tag> Tags
        )
    {
        public static explicit operator GetDocumentQueryResponse(Document document) =>
            new GetDocumentQueryResponse(document.Id,
                                         document.CategoryId,
                                         document.CustomerId,
                                         document.UserId,
                                         document.Title, 
                                         document.Description,
                                         document.CreatedOnUtc,
                                         document.Tags);
    }
}
