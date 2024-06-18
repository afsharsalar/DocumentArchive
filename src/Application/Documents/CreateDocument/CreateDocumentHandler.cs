namespace DocumentArchive.Application.Documents.CreateDocument;

public class CreateDocumentHandler(IDocumentRepository documentRepository) : IRequestHandler<CreateDocumentCommand, CreateDocumentResponse>
{
    public async Task<CreateDocumentResponse> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        var document=Document.CreateDocument(request.UserId,request.CustomerId,request.CategoryId,request.Title,request.Description,request.Tags);
        documentRepository.Create(document);
        await documentRepository.SaveChangesAsync(cancellationToken);
        return new CreateDocumentResponse(document.Id);
    }
}
