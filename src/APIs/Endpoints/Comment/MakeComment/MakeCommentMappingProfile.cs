
using DocumentArchive.Domain.DocumentAggregator;

namespace DocumentArchive.APIs.Endpoints.Comment.MakeComment
{
    public class MakeCommentMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<MakeCommentRequest, MakeCommentCommand>()
                .Map(p => p.DocumentId, src => DocumentId.Create(src.DocumentId));

            config.ForType<MakeCommentCommandResponse, MakeCommentResponse>()
                .Map(p => p.CommentId, src => src.CommentId.Value);
        }
    }
}
