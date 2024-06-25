﻿using DocumentArchive.Common.Domain;

namespace DocumentArchive.Domain.CustomerAggregator
{
    public class Customer : BaseAggregateRoot<CustomerId>
    {
        public Customer(CustomerId id) : base(id)
        {
        }

        private Customer() : this(null!) { }
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

        public void UpdateCustomer(CustomerType type, string title, Address address)
        {
            Type = type;
            Title = title;
            Address = address;
        }
    }
}
