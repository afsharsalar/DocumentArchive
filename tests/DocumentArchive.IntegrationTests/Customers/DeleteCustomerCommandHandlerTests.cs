using DocumentArchive.Application.Customers.DeleteCustomer;
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
    public class DeleteCustomerCommandHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public DeleteCustomerCommandHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture;
        }


        [Fact]
        public async Task handler_should_delete_customer()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new CustomerRepository(_fixture.BuildDbContext(dbName));
            var handler = new DeleteCustomerCommandHandler(repository);

            var customer = Customer.Create(
                Domain.CustomerAggregator.CustomerType.Real,
                "Title",
                new Domain.CustomerAggregator.Address
                {
                    City = "Urmia",
                    PostalCode = "1111111111",
                    Street = "Street 1"
                });

            repository.Create(customer);
            await repository.SaveChangesAsync(CancellationToken.None);


            var command = new DeleteCustomerCommand(customer.Id);
            
            //act and assert

                       
            await handler.Handle(command,CancellationToken.None);

            var fetch =await repository.GetById(customer.Id, CancellationToken.None);

            fetch.Should().BeNull();

        }

        [Fact]
        public async Task handler_throw_exception_when_customer_not_found()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new CustomerRepository(_fixture.BuildDbContext(dbName));
            var handler = new DeleteCustomerCommandHandler(repository);

            var command=new DeleteCustomerCommand(CustomerId.CreateUniqueId());

            //act
            Func<Task> act = () => handler.Handle(command, CancellationToken.None);

            //assert

            await act.Should().ThrowAsync<NotFoundCustomerException>();
        }
    }
}
