using DocumentArchive.Domain.DocumentAggregator;

namespace DocumentArchive.Application.Comments.MakeComment
{
    public record MakeCommentCommand
        (DocumentId DocumentId, int UserId, string Content) : IRequest<MakeCommentCommandResponse>;
}
