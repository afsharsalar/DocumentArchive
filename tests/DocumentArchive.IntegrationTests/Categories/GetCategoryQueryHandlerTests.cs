using DocumentArchive.Application.Categories.GetCategory;
using DocumentArchive.Domain.CategoryAggregator;
using DocumentArchive.Infrastructure.Persistence.Repositories;
using DocumentArchive.IntegrationTests.Fixtures;

using FluentAssertions;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentArchive.IntegrationTests.Categories
{
    public class GetCategoryQueryHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;

        public GetCategoryQueryHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture;
        }


        [Fact]
        public async Task should_return_exception_when_category_not_exist()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new CategoryRepository(_fixture.BuildDbContext(dbName));
            var handler = new GetCategoryQueryHandler(repository);
            var query = new GetCategoryQuery(CategoryId.CreateUniqueId());

            //act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);

            await act.Should().ThrowAsync<NotFoundCategoryException>();

        }

        [Fact]
        public async Task should_return_category_when_exist()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new CategoryRepository(_fixture.BuildDbContext(dbName));
            var handler = new GetCategoryQueryHandler(repository);
           

            var category1 = Category.Create("category 1", false);
            repository.Create(category1);
            await repository.SaveChangesAsync(CancellationToken.None);

            var query = new GetCategoryQuery(category1.Id);
            //act
            var response=await handler.Handle(query, CancellationToken.None);
            response.Should().NotBeNull();
            response?.CategoryId.Should().Be(category1.Id);
        }
        
    }
}
