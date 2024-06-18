using DocumentArchive.Domain.CommentAggregator;

namespace DocumentArchive.Application.Comments.GetComments;

public record GetCommentsQueryResponse(int UserId, DateTime CreatedOnUtc, string Content)
{
    public static explicit operator GetCommentsQueryResponse(Comment comment) =>
        new GetCommentsQueryResponse(comment.UserId,comment.CreatedOnUtc, comment.Content);
}