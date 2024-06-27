using DocumentArchive.Application.Documents.GetDocuments;

namespace DocumentArchive.APIs.Endpoints.Document.GetDocuments
{
    public class GetDocumentsEndPoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/documents", async (
                [AsParameters] GetDocumentsRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GetDocumentsQuery>(request);
                var result = await mediator.Send(command, cancellationToken);

                return mapper.Map<IEnumerable<GetDocumentsResponse>>(result);
            })
        .WithTags(EndpointSchema.CategoryTag);
        }
    }
}
