using DocumentArchive.Domain.CustomerAggregator;

namespace DocumentArchive.APIs.Endpoints.Customer.GetCustomer
{
    public record GetCustomerResponse(Guid CustomerId,
        CustomerType Type,
        string Title,
        string City,
        string Street,
        string PostalCode);
}
