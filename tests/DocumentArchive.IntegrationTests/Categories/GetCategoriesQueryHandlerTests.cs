using DocumentArchive.Application.Categories.GetCategories;
using DocumentArchive.Domain.CategoryAggregator;
using DocumentArchive.Infrastructure.Persistence.Repositories;
using DocumentArchive.IntegrationTests.Fixtures;

using FluentAssertions;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentArchive.IntegrationTests.Categories
{
    public class GetCategoriesQueryHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public GetCategoriesQueryHandlerTests(DbContextFixture fixture)
        {

            _fixture = fixture; 

        }


        [Fact]
        public async Task should_return_expected_data()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new CategoryRepository(_fixture.BuildDbContext(dbName));
            var handler = new GetCategoriesQueryHandler(repository);
            var query = new GetCategoriesQuery();

            var count = 20;

            for(var i=1;i<=count;i++)
            {
                repository.Create(Category.Create($"title {i}", false));
            }

            

            await repository.SaveChangesAsync(CancellationToken.None);

            //act
            var result =await handler.Handle(query, CancellationToken.None);

            result.Should().NotBeNull();
            result.Count.Should().Be(query.PageSize);

        }
    }
}
