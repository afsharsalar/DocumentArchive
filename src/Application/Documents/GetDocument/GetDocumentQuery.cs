namespace DocumentArchive.Application.Documents.GetDocument;

public record GetDocumentQuery(DocumentId DocumentId): IRequest<GetDocumentQueryResponse>;

