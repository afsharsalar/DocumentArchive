using DocumentArchive.Application.Comments.MakeComment;
using DocumentArchive.Application.Documents.UpdateDocument;
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

using Document = DocumentArchive.Domain.DocumentAggregator.Document;

namespace DocumentArchive.IntegrationTests.Documents
{
    public class UpdateDocumentCommandHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public UpdateDocumentCommandHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture;
        }



        [Fact]
        public async Task should_update_when_exist()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new DocumentRepository(_fixture.BuildDbContext(dbName));
            var handler = new UpdateDocumentCommandHandler(repository);


            var document = Document.CreateDocument(1,
                    CustomerId.CreateUniqueId(),
                    CategoryId.CreateUniqueId(),
                    "Title",
                    "Desc",
                    [Tag.Create("Tag1")]);
            repository.Create(document);
            

            await repository.SaveChangesAsync(CancellationToken.None);


            var command = new UpdateDocumentCommand(document.Id,
                document.CategoryId,
                document.CustomerId,
                "Title 2",
                "Desc 2",
                [Tag.Create("Tag 2")]);

            //act
            var response = await handler.Handle(command, CancellationToken.None);

            response.Should().NotBeNull();


            var fetch = await repository.GetById(document.Id, CancellationToken.None);
            fetch.Should().NotBeNull();
            fetch?.Title.Should().Be(command.Title);
            fetch?.Description.Should().Be(command.Description);
            fetch?.Tags.First().ToString().Should().Be("tag-2");


        }



        [Fact]
        public async Task should_throw_exception_when_not_exist()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new DocumentRepository(_fixture.BuildDbContext(dbName));
            var handler = new UpdateDocumentCommandHandler(repository);


            var command = new UpdateDocumentCommand(
                DocumentId.CreateUniqueId(),
                CategoryId.CreateUniqueId(),
                CustomerId.CreateUniqueId(),
                 "Title 2",
                 "Desc 2",
                 [Tag.Create("Tag 2")]);

           

            //act
            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<NotFoundDocumentException>();






        }
    }
}
