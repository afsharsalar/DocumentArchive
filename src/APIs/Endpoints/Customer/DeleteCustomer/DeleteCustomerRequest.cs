namespace DocumentArchive.APIs.Endpoints.Customer.DeleteCustomer
{
    public record DeleteCustomerRequest([FromRoute] Guid CustomerId);
}
