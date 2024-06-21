namespace DocumentArchive.Application.Documents.CreateDocument;

public class CreateDocumentCommandHandler(IDocumentRepository documentRepository) : IRequestHandler<CreateDocumentCommand, CreateDocumentCommandResponse>
{
    public async Task<CreateDocumentCommandResponse> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        var document=Document.CreateDocument(request.UserId,request.CustomerId,request.CategoryId,request.Title,request.Description,request.Tags);
        documentRepository.Create(document);
        await documentRepository.SaveChangesAsync(cancellationToken);
        return new CreateDocumentCommandResponse(document.Id);
    }
}
