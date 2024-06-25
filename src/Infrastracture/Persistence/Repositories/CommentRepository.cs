﻿using DocumentArchive.Domain.CommentAggregator;
using DocumentArchive.Domain.DocumentAggregator;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace DocumentArchive.Infrastructure.Persistence.Repositories;

public class CommentRepository(DocumentArchiveDbContext context) : ICommentRepository
{
    
    public async Task CreateAsync(Comment comment, CancellationToken cancellationToken)
    {
        await context.Comments.AddAsync(comment, cancellationToken);
    }

    public Task DeleteAsync(CommentId commentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Comment?> GetById(CommentId commentId, CancellationToken cancellationToken)
    {
        return context.Comments
            .SingleOrDefaultAsync(p => p.Id == commentId, cancellationToken);
    }

    public async Task<IReadOnlyList<Comment>> GetDocumentCommentsAsync(DocumentId documentId, CancellationToken cancellationToken)
    {
        var result= await context.Comments
            .Where(p => p.DocumentId.Value == documentId.Value)
            .ToListAsync(cancellationToken);
        return result.ToImmutableList();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateAsync(Comment comment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
