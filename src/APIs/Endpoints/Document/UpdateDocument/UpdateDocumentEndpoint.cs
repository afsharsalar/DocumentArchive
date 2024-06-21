
using DocumentArchive.Application.Documents.UpdateDocument;

namespace DocumentArchive.APIs.Endpoints.Document.UpdateDocument;

public class UpdateDocumentEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/documents/{documentId}", async (
           [FromRoute] Guid documentId,
           [FromBody] UpdateDocumentRequest request,
           IMapper mapper,
           IMediator mediator,
           CancellationToken cancellationToken) =>
        {
            if(documentId!=request.DocumentId) return Results.NotFound();

            var command = mapper.Map<UpdateDocumentCommand>(request);

            await mediator.Send(command, cancellationToken);
            return Results.Ok();

        }).Validator<UpdateDocumentRequest>()
     .WithTags(EndpointSchema.DocumentTag);
    }
}
