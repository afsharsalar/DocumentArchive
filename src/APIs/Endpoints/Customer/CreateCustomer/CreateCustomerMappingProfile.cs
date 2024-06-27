using DocumentArchive.Application.Customers.CreateCustomer;
using DocumentArchive.Domain.CustomerAggregator;

namespace DocumentArchive.APIs.Endpoints.Customer.CreateCustomer
{
    public class CreateCustomerMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<CreateCustomerRequest, CreateCustomerCommand>()
                .Map(p=>p.Address,src=>new Address { 
                    City=src.City,
                    Street=src.Street,
                    PostalCode=src.PostalCode,
                });

            config.ForType<CreateCustomerCommandResponse, CreateCustomerResponse>()
                .Map(p => p.CustomerId, src => src.CustomerId.Value);
        }
    }
}
