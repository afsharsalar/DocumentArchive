using DocumentArchive.Application.Comments.GetComments;
using DocumentArchive.Domain.DocumentAggregator;

namespace DocumentArchive.APIs.Endpoints.Comment.GetComments;

public class GetCommentsMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetCommentsRequest, GetCommentsQuery>()
            .Map(x => x.DocumentId, src => DocumentId.Create(src.DocumentId));

        config.ForType<GetCommentsQueryResponse, GetCommentsResponse>();
            

    }
}
