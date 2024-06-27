using DocumentArchive.Application.Customers.UpdateCustomer;
using DocumentArchive.Domain.CustomerAggregator;

namespace DocumentArchive.APIs.Endpoints.Customer.UpdateCustomer
{
    public class UpdateCustomerMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<UpdateCustomerRequest, UpdateCustomerCommand>()
                .Map(p=>p.CustomerId,src=>CustomerId.Create(src.CustomerId))
                .Map(p => p.Address, src => new Address
                {
                    City = src.City,
                    Street = src.Street,
                    PostalCode = src.PostalCode,
                });

            config.ForType<UpdateCustomerCommandResponse, UpdateCustomerResponse>()
                .Map(p=>p.CustomerId,src=>src.CustomerId.Value); 
        }
    }
}
