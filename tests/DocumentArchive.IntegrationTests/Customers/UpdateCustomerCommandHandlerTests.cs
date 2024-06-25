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
    public class UpdateCustomerCommandHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public UpdateCustomerCommandHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task handler_should_update_customer()
        {

            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new CustomerRepository(_fixture.BuildDbContext(dbName));
            var handler = new UpdateCustomerCommandHandler(repository);

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

            var command = new UpdateCustomerCommand(customer.Id,
                CustomerType.Legal,
                "Title2",
                new Address
                {
                    City = "Urmia2",
                    PostalCode = "222222222",
                    Street = "Street 2"
                });

            //act
            var response =await handler.Handle(command, CancellationToken.None);


            //assert
            response.Should().NotBeNull();
            
            var fetch =await repository.GetById(response.CustomerId, CancellationToken.None);
            

            fetch.Should().NotBeNull();
            fetch?.Title.Should().Be(command.Title);
            fetch?.Type.Should().Be(command.Type);  
            fetch?.Address.Should().Be(command.Address);    

        }

        [Fact]
        public async Task handler_throw_exception_for_not_found()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new CustomerRepository(_fixture.BuildDbContext(dbName));
            var handler = new UpdateCustomerCommandHandler(repository);

            var command = new UpdateCustomerCommand(CustomerId.CreateUniqueId(), CustomerType.Real, "", null);
            //act

            Func<Task> act =  () =>  handler.Handle(command, CancellationToken.None);

            //assert
            await act.Should().ThrowAsync<NotFoundCustomerException>();

        }
    }
}
