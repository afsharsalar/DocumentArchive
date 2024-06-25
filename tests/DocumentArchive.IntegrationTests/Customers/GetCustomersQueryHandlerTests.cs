using DocumentArchive.Application.Customers.GetCustomers;
using DocumentArchive.Domain.CustomerAggregator;
using DocumentArchive.Infrastructure.Persistence.Repositories;
using DocumentArchive.IntegrationTests.Fixtures;

using FluentAssertions;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentArchive.IntegrationTests.Customers;

public class GetCustomersQueryHandlerTests : IClassFixture<DbContextFixture>
{
    private readonly DbContextFixture _fixture;
    public GetCustomersQueryHandlerTests(DbContextFixture fixture)
    {
        _fixture = fixture;
    }


    [Fact]
    public async Task handler_should_return_paged()
    {
        //arrange            
        var dbName = Guid.NewGuid().ToString();
        var repository = new CustomerRepository(_fixture.BuildDbContext(dbName));
        var handler = new GetCustomersQueryHandler(repository);

        var count = 20;

        for (var i = 1; i <= count; i++)
        {
            repository.Create(Customer.Create(CustomerType.Real,$"Title-{i}",new Address { }));
        }
        await repository.SaveChangesAsync(CancellationToken.None);


        var query = new GetCustomersQuery();
        //act

        var response =await handler.Handle(query, CancellationToken.None);

        response.Should().NotBeNull();
        response.Count.Should().Be(query.PageSize);

    }
}
