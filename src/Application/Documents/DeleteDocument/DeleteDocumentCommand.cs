namespace DocumentArchive.Application.Documents.DeleteDocument;

public record DeleteDocumentCommand(DocumentId DocumentId) : IRequest;

