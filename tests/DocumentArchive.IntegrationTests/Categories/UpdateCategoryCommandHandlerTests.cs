using DocumentArchive.Application.Categories.CreateCategory;
using DocumentArchive.Application.Categories.GetCategory;
using DocumentArchive.Application.Categories.UpdateCategory;
using DocumentArchive.Domain.CategoryAggregator;
using DocumentArchive.Infrastructure.Persistence.Repositories;
using DocumentArchive.IntegrationTests.Fixtures;

using FluentAssertions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentArchive.IntegrationTests.Categories
{
    public class UpdateCategoryCommandHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public UpdateCategoryCommandHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture;
        }


        [Fact]
        public async Task should_update_when_exist()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new CategoryRepository(_fixture.BuildDbContext(dbName));
            var handler = new UpdateCategoryCommandHandler(repository);


            var category = Category.Create("Title1", true);
            repository.Create(category);

            await repository.SaveChangesAsync(CancellationToken.None);

            
            var command = new UpdateCategoryCommand(category.Id, "Category 1",false);

            //act
            var response =await handler.Handle(command, CancellationToken.None);

            response.Should().NotBeNull();


            var fetch =await repository.GetById(category.Id, CancellationToken.None);
            fetch.Should().NotBeNull();
            fetch?.Title.Should().Be(command.Title);


        }



        [Fact]
        public async Task should_throw_exception_when_not_exist()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new CategoryRepository(_fixture.BuildDbContext(dbName));
            var handler = new UpdateCategoryCommandHandler(repository);


            var category = Category.Create("Title1", true);
            repository.Create(category);

            await repository.SaveChangesAsync(CancellationToken.None);


            var command = new UpdateCategoryCommand(CategoryId.CreateUniqueId(), "Category 1", false);

            //act
          
            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<NotFoundCategoryException>();



        }
    }
}
