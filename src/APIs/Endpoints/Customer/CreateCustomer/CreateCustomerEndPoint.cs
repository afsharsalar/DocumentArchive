
using DocumentArchive.Application.Customers.CreateCustomer;

namespace DocumentArchive.APIs.Endpoints.Customer.CreateCustomer
{
    public class CreateCustomerEndPoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/customers", async (
                [FromBody] CreateCustomerRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<CreateCustomerCommand>(request);
                var response =await  mediator.Send(command, cancellationToken);
                return mapper.Map<CreateCustomerResponse>(response);
            }).Validator<CreateCustomerRequest>().WithTags(EndpointSchema.CustomerTag);
        }
    }
}
