using DocumentArchive.Application.Customers.GetCustomers;

namespace DocumentArchive.APIs.Endpoints.Customer.GetCustomers
{
    public class GetCustomersMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<GetCustomersRequest, GetCustomersQuery>();
            
            config.ForType<GetCustomersQueryResponse, GetCustomersResponse>()
                .Map(p => p.CustomerId, src => src.CustomerId.Value)
                .Map(p => p.Street, src => src.Address.Street)
                .Map(p => p.City, src => src.Address.City)
                .Map(p => p.PostalCode, src => src.Address.PostalCode)
                .Map(p => p.CustomerId, src => src.CustomerId.Value);
        }
    }
}
