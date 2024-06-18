using DocumentArchive.Domain.DocumentAggregator;

namespace DocumentArchive.Application.Comments.GetComments;

public record class GetCommentsQuery(DocumentId DocumentId) : IRequest<IReadOnlyList<GetCommentsQueryResponse>>;