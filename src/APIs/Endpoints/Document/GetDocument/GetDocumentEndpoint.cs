

using DocumentArchive.Application.Documents.GetDocument;

namespace DocumentArchive.APIs.Endpoints.Document.GetDocument
{
    public class GetDocumentEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/documents/{documentId}", async (
                [AsParameters] GetDocumentRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GetDocumentQuery>(request);
                var result = await mediator.Send(command, cancellationToken);

                return mapper.Map<GetDocumentResponse>(result);
            })
        .WithTags(EndpointSchema.DocumentTag);
        }
    }
}
