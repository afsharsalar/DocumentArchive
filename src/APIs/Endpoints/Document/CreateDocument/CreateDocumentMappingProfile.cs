using DocumentArchive.Application.Documents.CreateDocument;
using DocumentArchive.Domain.CategoryAggregator;
using DocumentArchive.Domain.CustomerAggregator;
using DocumentArchive.Domain.DocumentAggregator;

namespace DocumentArchive.APIs.Endpoints.Document.CreateDocument
{
    public class CreateDocumentMappingProfile:IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<CreateDocumentRequest, CreateDocumentCommand>()
                .Map(p=>p.CategoryId,p=> CategoryId.Create(p.CategoryId))
                .Map(p => p.CustomerId, p => CustomerId.Create(p.CustomerId))            
                .Map(x => x.Tags, src => src.Tags.Select(x => Tag.Create(x))
                                                    .ToImmutableList());

            config.ForType<CreateDocumentCommandResponse, CreateDocumentResponse>()
                      .Map(x => x.DocumentId, src => src.DocumentId.Value);
        }
    }
}
