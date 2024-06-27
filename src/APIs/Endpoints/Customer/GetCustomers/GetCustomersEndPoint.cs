
using DocumentArchive.Application.Customers.GetCustomers;

namespace DocumentArchive.APIs.Endpoints.Customer.GetCustomers
{
    public class GetCustomersEndPoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/customers", async (
                [AsParameters] GetCustomersRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var query = mapper.Map<GetCustomersQuery>(request);
                var response= await mediator.Send(query,cancellationToken);
                return mapper.Map<IEnumerable<GetCustomersResponse>>(response);

            }).WithTags(EndpointSchema.CustomerTag);
        }
    }
}
