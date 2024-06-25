namespace DocumentArchive.Application.Customers.CreateCustomer;

public class CreateCustomerCommandHandler(ICustomerRepository customerRepository) : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
{
    public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = Customer.Create(request.Type,
            request.Title,
            request.Address);

        customerRepository.Create(customer);
        await customerRepository.SaveChangesAsync(cancellationToken);

        return new CreateCustomerCommandResponse(customer.Id);
            
    }
}
