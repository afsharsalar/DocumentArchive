using DocumentArchive.Application.Customers.UpdateCustomer;

namespace DocumentArchive.Application.Customers.GetCustomer;

public class GetCustomerQueryHandler(ICustomerRepository customerRepository) : IRequestHandler<GetCustomerQuery, GetCustomerQueryResponse>
{
    public async Task<GetCustomerQueryResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer =await customerRepository.GetById(request.CustomerId, cancellationToken);
        if(customer == null) { throw new NotFoundCustomerException(); }
        return (GetCustomerQueryResponse)customer;
    }
}
