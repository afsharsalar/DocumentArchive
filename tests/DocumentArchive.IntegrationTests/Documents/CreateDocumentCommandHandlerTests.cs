using DocumentArchive.Application.Documents.CreateDocument;
using DocumentArchive.Domain.CategoryAggregator;
using DocumentArchive.Domain.CustomerAggregator;
using DocumentArchive.Domain.DocumentAggregator;
using DocumentArchive.Infrastructure.Persistence.Repositories;
using DocumentArchive.IntegrationTests.Fixtures;

using FluentAssertions;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentArchive.IntegrationTests.Documents
{
    public class CreateDocumentCommandHandlerTests :IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;

        public CreateDocumentCommandHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task should_create_document()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new DocumentRepository(_fixture.BuildDbContext(dbName));
            var handler = new CreateDocumentCommandHandler(repository);

            int userId = 1;

            
            var command = new CreateDocumentCommand(CategoryId.CreateUniqueId(),
                CustomerId.CreateUniqueId(),
                userId,
                "Title",
                "Desc",
                [Tag.Create("Tag1"), Tag.Create("Tag2")]);

            //act
            var response =await handler.Handle(command, CancellationToken.None);

            response.Should().NotBeNull();

            var fetch =await repository.GetById(response.DocumentId, CancellationToken.None);

            fetch.Should().NotBeNull();
            fetch?.Title.Should().Be(command.Title);
            fetch?.Description.Should().Be(command.Description);
            fetch?.Tags.Count().Should().Be(2);

        }

    }

}
