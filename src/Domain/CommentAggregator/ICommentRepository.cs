using DocumentArchive.Domain.DocumentAggregator;

namespace DocumentArchive.Domain.CommentAggregator
{
    public interface ICommentRepository
    {

        Task<IReadOnlyList<Comment>> GetDocumentCommentsAsync(DocumentId documentId,CancellationToken cancellationToken);

        Task UpdateAsync(Comment comment,CancellationToken cancellationToken);
        Task CreateAsync(Comment comment,CancellationToken cancellationToken);

        Task DeleteAsync(CommentId commentId, CancellationToken cancellationToken);

        Task<Comment?> GetById(CommentId commentId,CancellationToken cancellationToken);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
