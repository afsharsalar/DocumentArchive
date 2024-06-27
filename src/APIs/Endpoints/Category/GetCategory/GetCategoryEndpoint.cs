
using DocumentArchive.Application.Categories.GetCategory;

namespace CategoryArchive.APIs.Endpoints.Category.GetCategory
{
    public class GetCategoryEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/categories/{categoryId}", async (
                [AsParameters] GetCategoryRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var query = mapper.Map<GetCategoryQuery>(request);
                var result = await mediator.Send(query, cancellationToken);

                return mapper.Map<GetCategoryResponse>(result);
            })
        .WithTags(EndpointSchema.CategoryTag);
        }
    }
}
