using DocumentArchive.Application.Documents.GetDocuments;

namespace DocumentArchive.APIs.Endpoints.Document.GetDocuments
{
    public class GetDocumentsMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<GetDocumentsRequest, GetDocumentsQuery>();

            config.ForType<GetDocumentsQueryResponse, GetDocumentsResponse>()
                .Map(p => p.DocumentId, src => src.DocumentId.Value)
                .Map(p => p.CategoryId, src => src.CategoryId == null ? (Guid?)null : src.CategoryId.Value)
                .Map(p => p.CustomerId, src => src.CustomerId == null ? (Guid?)null : src.CustomerId.Value)
                .Map(p => p.Tags, src => src.Tags.Select(x => x.Value).ToImmutableList());
        }
    }
}
