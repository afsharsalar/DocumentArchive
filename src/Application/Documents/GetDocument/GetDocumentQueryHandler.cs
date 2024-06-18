using DocumentArchive.Application.Exceptions;

namespace DocumentArchive.Application.Documents.GetDocument
{
    public class GetDocumentQueryHandler(IDocumentRepository documentRepository) : IRequestHandler<GetDocumentQuery, GetDocumentQueryResponse>
    {
        private readonly IDocumentRepository _documentRepository = documentRepository;

        public async Task<GetDocumentQueryResponse> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
        {
            var document =await _documentRepository.GetById(request.DocumentId, cancellationToken);
            if (document == null) {  throw new NotFoundDocumentException(); }
            return (GetDocumentQueryResponse)document;
        }
    }
}
