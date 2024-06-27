using DocumentArchive.Application.Documents.GetDocument;
using DocumentArchive.Domain.DocumentAggregator;

namespace DocumentArchive.APIs.Endpoints.Document.GetDocument;

public class GetDocumentMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetDocumentRequest, GetDocumentQuery>()
            .Map(p=>p.DocumentId,src=>DocumentId.Create(src.DocumentId));

        config.ForType<GetDocumentQueryResponse, GetDocumentResponse>()
            .Map(p => p.DocumentId, src => src.DocumentId.Value)
            .Map(p => p.CategoryId, src => src.CategoryId == null ? (Guid?)null : src.CategoryId.Value)
            .Map(p => p.CustomerId, src => src.CustomerId == null ? (Guid?)null : src.CustomerId.Value)
            .Map(p => p.Tags, src => src.Tags.Select(x => x.Value).ToImmutableList());
    }
}
