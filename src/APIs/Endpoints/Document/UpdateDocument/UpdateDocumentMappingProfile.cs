using DocumentArchive.Application.Documents.UpdateDocument;
using DocumentArchive.Domain.CategoryAggregator;
using DocumentArchive.Domain.CustomerAggregator;
using DocumentArchive.Domain.DocumentAggregator;

namespace DocumentArchive.APIs.Endpoints.Document.UpdateDocument;

public class UpdateDocumentMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<UpdateDocumentRequest, UpdateDocumentCommand>()
            .Map(p => p.DocumentId, p => DocumentId.Create(p.DocumentId))
            .Map(p => p.CategoryId, p => CategoryId.Create(p.CategoryId))
            .Map(p => p.CustomerId, p => CustomerId.Create(p.CustomerId))
            .Map(x => x.Tags, src => src.Tags.Select(x => Tag.Create(x))
                                                .ToImmutableList());

        config.ForType<UpdateDocumentCommandResponse, UpdateDocumentResponse>()
                  .Map(x => x.DocumentId, src => src.DocumentId.Value);
    }
}
