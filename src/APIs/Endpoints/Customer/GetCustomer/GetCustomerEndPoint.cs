
using DocumentArchive.Application.Customers.GetCustomer;

namespace DocumentArchive.APIs.Endpoints.Customer.GetCustomer
{
    public class GetCustomerEndPoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/customers/{customerId}", async (
                [AsParameters] GetCustomerRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationTone) =>
            {
                var query = mapper.Map<GetCustomerQuery>(request);
                var result = await mediator.Send(query, cancellationTone);
                return mapper.Map<GetCustomerResponse>(result);
            }).WithTags(EndpointSchema.CustomerTag); 
        }
    }
}
