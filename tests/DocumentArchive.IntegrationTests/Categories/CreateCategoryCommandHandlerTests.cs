using DocumentArchive.Application.Categories.CreateCategory;
using DocumentArchive.Infrastructure.Persistence.Repositories;
using DocumentArchive.IntegrationTests.Fixtures;

using FluentAssertions;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentArchive.IntegrationTests.Categories
{
    public class CreateCategoryCommandHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;

        public CreateCategoryCommandHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture;
        }


        [Fact]
        public async Task handle_should_create_category()
        {
            //arrange
            var dbName= Guid.NewGuid().ToString();
            var repository = new CategoryRepository(_fixture.BuildDbContext(dbName));
            var handler=new CreateCategoryCommandHandler(repository);
            var command = new CreateCategoryCommand("Category 1");

            //act

            var response = await handler.Handle(command, CancellationToken.None);
            
            //assert

            response.Should().NotBeNull();
            response.CategoryId.Should().NotBeNull();
            
            var category = await repository.GetById(response.CategoryId,CancellationToken.None);
            category.Should().NotBeNull();
            category?.Title.Should().Be(command.Title);
        }
    }
}
