
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
                var command = mapper.Map<GetCategoryQuery>(request);
                var result = await mediator.Send(command, cancellationToken);

                return mapper.Map<GetCategoryResponse>(result);
            }).Validator<GetCategoryRequest>()
        .WithTags(EndpointSchema.CategoryTag);
        }
    }
}
