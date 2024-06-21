
using DocumentArchive.Application.Documents.CreateDocument;

namespace DocumentArchive.APIs.Endpoints.Document.CreateDocument
{
    public class CreateDocumentEndPoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/documents/", async (
                [FromBody] CreateDocumentRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<CreateDocumentCommand>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map<CreateDocumentResponse>(response);
            }).Validator<CreateDocumentRequest>()
          .WithTags(EndpointSchema.DocumentTag);
        }
    }
}
