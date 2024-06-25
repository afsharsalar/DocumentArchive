using DocumentArchive.Application.Customers.CreateCustomer;
using DocumentArchive.Infrastructure.Persistence.Repositories;
using DocumentArchive.IntegrationTests.Fixtures;

using FluentAssertions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentArchive.IntegrationTests.Customers
{
    public class CreateCustomerCommandHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;

        public CreateCustomerCommandHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture;
        }


        [Fact]
        public async Task handle_should_create_customer()
        {
            //arrange
            var dbName= Guid.NewGuid().ToString();
            var repository = new CustomerRepository(_fixture.BuildDbContext(dbName));
            var handler = new CreateCustomerCommandHandler(repository);

            var command = new CreateCustomerCommand(
                Domain.CustomerAggregator.CustomerType.Real,
                "Title",
                new Domain.CustomerAggregator.Address 
                {
                    City="Urmia",
                    PostalCode="1111111111",
                    Street="Street 1"
                });

            //act

            var response= await handler.Handle(command,CancellationToken.None);

            response.Should().NotBeNull();

            var fetch =await repository.GetById(response.CustomerId, CancellationToken.None);

            fetch.Should().NotBeNull();
            fetch?.Title.Should().Be(command.Title);
            fetch?.Type.Should().Be(command.Type);
            fetch?.Address.Should().Be(command.Address);

        }
    
    }
}
