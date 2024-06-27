using DocumentArchive.APIs.Endpoints.Category.UpdateCategory;
using DocumentArchive.Application.Categories.UpdateCategory;

namespace CategoryArchive.APIs.Endpoints.Category.UpdateCategory
{
    public class UpdateCategoryEndPoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("/categories", async (               
                [FromBody] UpdateCategoryRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                // Check if id matches the request's CategoryId if necessary
                // if (id != request.CategoryId) return Results.NotFound();

                var command = mapper.Map<UpdateCategoryCommand>(request);
                var response = await mediator.Send(command, cancellationToken);

             
                return Results.Ok(mapper.Map<UpdateCategoryResponse>(response));


            }).Validator<UpdateCategoryRequest>()
          .WithTags(EndpointSchema.CategoryTag);
        }
    }
}
