using DocumentArchive.Domain.Common;

namespace DocumentArchive.Domain.CustomerAggregator
{
    public class Customer : BaseAggregateRoot<CustomerId>
    {
        public Customer(CustomerId id) : base(id)
        {
        }

        public CustomerType Type { get; set; }

        public string Title { get; set; }

        public Address Address { get; set; }


        public static Customer Create(CustomerType type, string title, Address address)
        {
            return new Customer(CustomerId.CreateUniqueId())
            {
                Title = title,
                Address = address,
                Type = type
                
            };
        }
    }
}
