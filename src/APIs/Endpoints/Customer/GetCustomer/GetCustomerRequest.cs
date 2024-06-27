namespace DocumentArchive.APIs.Endpoints.Customer.GetCustomer
{
    public record GetCustomerRequest([FromRoute] Guid CustomerId);
}
