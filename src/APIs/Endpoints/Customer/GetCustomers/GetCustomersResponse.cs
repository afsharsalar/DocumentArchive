using DocumentArchive.Domain.CustomerAggregator;

namespace DocumentArchive.APIs.Endpoints.Customer.GetCustomers
{
    public record GetCustomersResponse(Guid CustomerId,
        CustomerType Type,
        string Title,
        string City,
        string Street,
        string PostalCode);
}
