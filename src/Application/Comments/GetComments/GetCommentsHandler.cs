using DocumentArchive.Domain.CommentAggregator;

namespace DocumentArchive.Application.Comments.GetComments;

public class GetCommentsHandler(ICommentRepository commentRepository):
    IRequestHandler<GetCommentsQuery,IReadOnlyList<GetCommentsQueryResponse>>
{
    private readonly ICommentRepository _commentRepository=commentRepository;

    public async Task<IReadOnlyList<GetCommentsQueryResponse>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetDocumentCommentsAsync(request.DocumentId, cancellationToken);
        return comments.Select(p => (GetCommentsQueryResponse)p).ToImmutableList();
    }
}