
using DocumentArchive.APIs.Endpoints.Customer.GetCustomer;
using DocumentArchive.Application.Customers.DeleteCustomer;

namespace DocumentArchive.APIs.Endpoints.Customer.DeleteCustomer
{
    public class DeleteCustomerEndPoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("/customers/{customerId}", async (
                [AsParameters] DeleteCustomerRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationTone) =>
            {
                var query = mapper.Map<DeleteCustomerCommand>(request);
                await mediator.Send(query, cancellationTone);
                
            }).WithTags(EndpointSchema.CustomerTag);
        }
    }
}
