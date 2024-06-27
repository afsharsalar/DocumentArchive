using DocumentArchive.Domain.CustomerAggregator;

namespace DocumentArchive.APIs.Endpoints.Customer.UpdateCustomer
{
    public record UpdateCustomerRequest(
        Guid CustomerId,
        CustomerType Type,
        string Title,
        string Street,
        string City,
        string PostalCode);
}
