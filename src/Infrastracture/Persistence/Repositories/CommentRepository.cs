using DocumentArchive.Domain.CommentAggregator;
using DocumentArchive.Domain.DocumentAggregator;

namespace DocumentArchive.Infrastructure.Persistence.Repositories;

public class CommentRepository : ICommentRepository
{
    public Task CreateAsync(Comment comment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(CommentId commentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Comment?> GetById(CommentId commentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Comment>> GetDocumentCommentsAsync(DocumentId documentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Comment comment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
