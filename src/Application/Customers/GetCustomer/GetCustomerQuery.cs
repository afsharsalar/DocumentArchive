namespace DocumentArchive.Application.Customers.GetCustomer
{
    public record GetCustomerQuery(CustomerId CustomerId) : IRequest<GetCustomerQueryResponse>;
    
}
