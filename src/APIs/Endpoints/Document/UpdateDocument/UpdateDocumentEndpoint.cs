
using DocumentArchive.Application.Documents.UpdateDocument;

namespace DocumentArchive.APIs.Endpoints.Document.UpdateDocument;

public class UpdateDocumentEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/documents/", async (
           
           [FromBody] UpdateDocumentRequest request,
           IMapper mapper,
           IMediator mediator,
           CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<UpdateDocumentCommand>(request);

            var response=await mediator.Send(command, cancellationToken);
            return mapper.Map<UpdateDocumentResponse>(response);

        }).Validator<UpdateDocumentRequest>()
     .WithTags(EndpointSchema.DocumentTag);
    }
}
