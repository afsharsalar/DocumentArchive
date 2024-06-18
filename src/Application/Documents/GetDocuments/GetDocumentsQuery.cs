
namespace DocumentArchive.Application.Documents.GetDocuments;

public record GetDocumentsQuery(int Page = 1, int PageSize = 10) :
    IRequest<IReadOnlyCollection<GetDocumentsQueryResponse>>;

