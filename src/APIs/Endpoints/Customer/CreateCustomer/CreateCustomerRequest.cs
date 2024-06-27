using DocumentArchive.Domain.CustomerAggregator;

namespace DocumentArchive.APIs.Endpoints.Customer.CreateCustomer
{
    public record CreateCustomerRequest(
        CustomerType Type,
        string Title,
        string Street,
        string City,
        string PostalCode);
    
}
