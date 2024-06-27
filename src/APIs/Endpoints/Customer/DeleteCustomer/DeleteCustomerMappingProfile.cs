using DocumentArchive.Application.Customers.DeleteCustomer;
using DocumentArchive.Domain.CustomerAggregator;

namespace DocumentArchive.APIs.Endpoints.Customer.DeleteCustomer
{
    public class DeleteCustomerMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<DeleteCustomerRequest, DeleteCustomerCommand>()
                .Map(p=>p.CustomerId,src=>CustomerId.Create(src.CustomerId));
        }
    }
}
