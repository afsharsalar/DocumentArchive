using DocumentArchive.Application.Customers.GetCustomer;
using DocumentArchive.Application.Customers.GetCustomers;
using DocumentArchive.Domain.CustomerAggregator;

namespace DocumentArchive.APIs.Endpoints.Customer.GetCustomer
{
    public class GetCustomerMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<GetCustomerRequest, GetCustomerQuery>()
                .Map(p => p.CustomerId, src => CustomerId.Create(src.CustomerId));

            config.ForType<GetCustomerQueryResponse, GetCustomerResponse>()
               
                .Map(p => p.Street, src => src.Address.Street)
                .Map(p => p.City, src => src.Address.City)
                .Map(p => p.PostalCode, src => src.Address.PostalCode)
                .Map(p => p.CustomerId, src => src.CustomerId.Value);
        }
    }
}
