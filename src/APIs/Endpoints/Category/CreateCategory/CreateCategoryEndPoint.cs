using DocumentArchive.APIs.Endpoints.Category.CreateCategory;
using DocumentArchive.Application.Categories.CreateCategory;

namespace CategoryArchive.APIs.Endpoints.Category.CreateCategory
{
    public class CreateCategoryEndPoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/categories/", async (
                [FromBody] CreateCategoryRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<CreateCategoryCommand>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map<CreateCategoryResponse>(response);
            }).Validator<CreateCategoryRequest>()
          .WithTags(EndpointSchema.CategoryTag)
          .RequireAuthorization();
        }
    }
}
