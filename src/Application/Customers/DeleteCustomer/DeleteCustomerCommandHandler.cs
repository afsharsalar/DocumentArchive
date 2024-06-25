using DocumentArchive.Application.Customers.UpdateCustomer;

namespace DocumentArchive.Application.Customers.DeleteCustomer;

public class DeleteCustomerCommandHandler(ICustomerRepository customerRepository) : IRequestHandler<DeleteCustomerCommand>
{
    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer =await customerRepository.GetById(request.CustomerId, cancellationToken);
        if(customer == null) { throw new NotFoundCustomerException(); }

        customerRepository.Delete(customer);
        await customerRepository.SaveChangesAsync(cancellationToken);

    }
}
