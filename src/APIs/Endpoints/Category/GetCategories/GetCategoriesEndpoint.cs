
using DocumentArchive.APIs.Endpoints.Category.GetCategories;
using DocumentArchive.Application.Categories.GetCategories;

namespace CategoryArchive.APIs.Endpoints.Category.GetCategory
{
    public class GetCategoriesEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/categories", async (
                [AsParameters]  GetCategoriesRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GetCategoriesQuery>(request);
                var result = await mediator.Send(command, cancellationToken);

                return mapper.Map<IEnumerable<GetCategoriesResponse>>(result);
            })
        .WithTags(EndpointSchema.CategoryTag);
        }
    }
}
