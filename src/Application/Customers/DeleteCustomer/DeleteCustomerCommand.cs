namespace DocumentArchive.Application.Customers.DeleteCustomer
{
    public record DeleteCustomerCommand(CustomerId CustomerId) : IRequest;
}
