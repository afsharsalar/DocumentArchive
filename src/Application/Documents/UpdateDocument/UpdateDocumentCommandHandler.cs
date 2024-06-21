using DocumentArchive.Application.Exceptions;

namespace DocumentArchive.Application.Documents.UpdateDocument;

public class UpdateDocumentCommandHandler(IDocumentRepository documentRepository) : IRequestHandler<UpdateDocumentCommand, UpdateDocumentCommandResponse>
{

    public async Task<UpdateDocumentCommandResponse> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
    {
        var document = await documentRepository.GetById(request.DocumentId, cancellationToken);
        if(document == null) throw new NotFoundDocumentException();

        var userId = 1;

        document.UpdateDocument(userId, request.CustomerId,
            request.CategoryId,
            request.Title,
            request.Description,
            request.Tags);

        documentRepository.Update(document);

        await documentRepository.SaveChangesAsync(cancellationToken);

        return new UpdateDocumentCommandResponse(document.Id);
        
    }
}
