namespace DocumentArchive.Application.Customers.GetCustomer
{
    public record GetCustomerQueryResponse(CustomerId CustomerId,
        CustomerType Type,
        string Title,
        Address Address)
    {
        public static explicit operator GetCustomerQueryResponse(Customer customer) =>
            new GetCustomerQueryResponse(
                customer.Id,
                customer.Type,
                customer.Title, customer.Address);
    }
}
