namespace DocumentArchive.Application.Documents.UpdateDocument;

public record UpdateDocumentCommand(
    DocumentId DocumentId,
    CategoryId CategoryId,
    CustomerId CustomerId,
    string Title,
    string Description,
    IReadOnlyList<Tag> Tags):IRequest<UpdateDocumentCommandResponse>;
