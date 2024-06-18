﻿using DocumentArchive.Domain.CommentAggregator;
using DocumentArchive.Domain.DocumentAggregator;

namespace DocumentArchive.Application.Comments.MakeComment
{
    public class MakeCommentCommandHandler: IRequestHandler<MakeCommentCommand,MakeCommentCommandResponse>
    {
        private readonly ICommentRepository _commentRepository ;
        private readonly IDocumentRepository _documentRepository;
        public MakeCommentCommandHandler(ICommentRepository commentRepository, IDocumentRepository documentRepository)
        {
            _commentRepository = commentRepository;
            _documentRepository = documentRepository;
        }


        public async Task<MakeCommentCommandResponse> Handle(MakeCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = Comment.Create(request.DocumentId, request.UserId, request.Content);
            await _commentRepository.CreateAsync(comment, cancellationToken);
            await _commentRepository.SaveChangesAsync(cancellationToken);

            return new MakeCommentCommandResponse(comment.Id);
        }
    }
}
