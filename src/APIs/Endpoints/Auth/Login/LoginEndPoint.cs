
using DocumentArchive.APIs.Endpoints.Category.CreateCategory;

using System.Threading;

namespace DocumentArchive.APIs.Endpoints.Auth.Login
{
    public class LoginEndPoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/Auth/Login/", async (
               [FromBody] LoginRequest request,
               IMapper mapper,
               IMediator mediator,
               CancellationToken cancellationToken) =>
            {
               

               
            }).Validator<LoginRequest>()
         .WithTags(EndpointSchema.AuthTag)
         .RequireAuthorization();
        }
    }
}
