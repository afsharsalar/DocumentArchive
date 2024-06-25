using DocumentArchive.Application.Customers.GetCustomer;
using DocumentArchive.Application.Customers.UpdateCustomer;
using DocumentArchive.Domain.CustomerAggregator;
using DocumentArchive.Infrastructure.Persistence.Repositories;
using DocumentArchive.IntegrationTests.Fixtures;

using FluentAssertions;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentArchive.IntegrationTests.Customers
{
    public class GetCustomerQueryHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public GetCustomerQueryHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture;
        }


        [Fact]
        public async Task handler_should_return_customer()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new CustomerRepository(_fixture.BuildDbContext(dbName));
            var handler = new GetCustomerQueryHandler(repository);


            var customer = Customer.Create(CustomerType.Real,
                "Title 1", new Address 
                { 
                    City="Urmia",
                });

            repository.Create(customer);
            await repository.SaveChangesAsync(CancellationToken.None);

            var query = new GetCustomerQuery(customer.Id);

            //act
            var response =await handler.Handle(query, CancellationToken.None);


            //assert
            response.Should().NotBeNull();
            response?.Title.Should().Be(customer.Title);
            response?.Type.Should().Be(customer.Type);
            response?.Address.Should().Be(customer.Address);

        }

        [Fact]
        public async Task handler_should_throw_exception_if_customer_not_exist()
        {

            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new CustomerRepository(_fixture.BuildDbContext(dbName));
            var handler = new GetCustomerQueryHandler(repository);

            var query = new GetCustomerQuery(CustomerId.CreateUniqueId());

            //act
            Func<Task> act= ()=>  handler.Handle(query, CancellationToken.None); 
            

            //assert
            await act.Should().ThrowAsync<NotFoundCustomerException>();



        }
    }
}
