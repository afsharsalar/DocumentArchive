namespace DocumentArchive.Application.Documents.CreateDocument
{
    public record CreateDocumentCommand(CategoryId CategoryId,
        CustomerId CustomerId,
        int UserId, 
        string Title,
        string Description,
        IReadOnlyList<Tag> Tags)
        :IRequest<CreateDocumentCommandResponse>;
    
}
