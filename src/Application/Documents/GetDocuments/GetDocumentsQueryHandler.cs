namespace DocumentArchive.Application.Documents.GetDocuments;

public class GetDocumentsQueryHandler(IDocumentRepository documentRepository) : IRequestHandler<GetDocumentsQuery, IReadOnlyCollection<GetDocumentsQueryResponse>>
{
    private readonly IDocumentRepository _documentRepository = documentRepository;

    public async Task<IReadOnlyCollection<GetDocumentsQueryResponse>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents=await _documentRepository.GetPaged(request.Page,request.PageSize, cancellationToken);
        return [.. documents.Select(x => (GetDocumentsQueryResponse)x)];
    }
}
