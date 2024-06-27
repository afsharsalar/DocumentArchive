using DocumentArchive.Application.Customers.UpdateCustomer;

namespace DocumentArchive.APIs.Endpoints.Customer.UpdateCustomer
{
    public class UpdateCustomerEndPoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("/customers/", async (
                
                [FromBody] UpdateCustomerRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                

                var command = mapper.Map<UpdateCustomerCommand>(request);
                var response = await mediator.Send(command, cancellationToken);


                return Results.Ok(mapper.Map<UpdateCustomerResponse>(response));


            }).Validator<UpdateCustomerRequest>()
          .WithTags(EndpointSchema.CustomerTag);
        }
    }
}
