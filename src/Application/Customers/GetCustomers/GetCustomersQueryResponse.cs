namespace DocumentArchive.Application.Customers.GetCustomers;

public record GetCustomersQueryResponse(CustomerId CustomerId,
        CustomerType Type,
        string Title,
        Address Address)
{
    public static explicit operator GetCustomersQueryResponse(Customer customer) =>
        new GetCustomersQueryResponse(
            customer.Id,
            customer.Type,
            customer.Title, customer.Address);
}
