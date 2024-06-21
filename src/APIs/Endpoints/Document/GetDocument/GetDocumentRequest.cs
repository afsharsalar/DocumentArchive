namespace DocumentArchive.APIs.Endpoints.Document.GetDocument;

public record GetDocumentRequest([FromRoute] Guid DocumentId);

