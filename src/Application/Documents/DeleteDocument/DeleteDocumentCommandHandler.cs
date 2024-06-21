using DocumentArchive.Application.Exceptions;

namespace DocumentArchive.Application.Documents.DeleteDocument;

public class DeleteDocumentCommandHandler(IDocumentRepository documentRepository) : IRequestHandler<DeleteDocumentCommand>
{
    public async Task Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
    {
        var document =await documentRepository.GetById(request.DocumentId, cancellationToken);
        if(document == null) { throw new NotFoundDocumentException(); }
        
        document.Remove();
        await documentRepository.SaveChangesAsync(cancellationToken);
    }
}
