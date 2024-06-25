
using DocumentArchive.APIs.Endpoints.Category.GetCategories;
using DocumentArchive.Application.Categories.GetCategories;

namespace CategoryArchive.APIs.Endpoints.Category.GetCategory
{
    public class GetCategoriesEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/categories", async (
                GetCategoriesRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GetCategoriesQuery>(request);
                var result = await mediator.Send(command, cancellationToken);

                return mapper.Map<GetCategoriesResponse>(result);
            }).Validator<GetCategoriesRequest>()
        .WithTags(EndpointSchema.CategoryTag);
        }
    }
}
