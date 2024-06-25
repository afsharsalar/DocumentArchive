namespace DocumentArchive.Application.Customers.UpdateCustomer;

public class UpdateCustomerCommandHandler(ICustomerRepository customerRepository) : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandResponse>
{
    public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer=await  customerRepository.GetById(request.CustomerId,cancellationToken);
        if(customer == null) { throw new NotFoundCustomerException(); }

        customer.UpdateCustomer(request.Type,
            request.Title,
            request.Address);

        await customerRepository.SaveChangesAsync(cancellationToken);

        return new UpdateCustomerCommandResponse(customer.Id);
            
    }
}
