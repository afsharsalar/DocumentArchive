using DocumentArchive.Application.Comments.MakeComment;
using DocumentArchive.Application.Documents.DeleteDocument;
using DocumentArchive.Application.Documents.UpdateDocument;
using DocumentArchive.Domain.CategoryAggregator;
using DocumentArchive.Domain.CustomerAggregator;
using DocumentArchive.Domain.DocumentAggregator;
using DocumentArchive.Infrastructure.Persistence.Repositories;
using DocumentArchive.IntegrationTests.Fixtures;

using FluentAssertions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentArchive.IntegrationTests.Documents
{
    public class DeleteDocumentCommandHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public DeleteDocumentCommandHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task should_delete_when_exist()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new DocumentRepository(_fixture.BuildDbContext(dbName));
            var handler = new DeleteDocumentCommandHandler(repository);


            var document = Document.CreateDocument(1,
                    CustomerId.CreateUniqueId(),
                    CategoryId.CreateUniqueId(),
                    "Title",
                    "Desc",
                    [Tag.Create("Tag1")]);
            repository.Create(document);


            await repository.SaveChangesAsync(CancellationToken.None);


            var command = new DeleteDocumentCommand(document.Id);

            //act
            await handler.Handle(command, CancellationToken.None);

            


            var fetch = await repository.GetById(document.Id, CancellationToken.None);
            fetch.Should().NotBeNull();
            fetch?.Status.Should().Be(Domain.CommentAggregator.DocumentStatus.Deleted);
            


        }



        [Fact]
        public async Task should_throw_exception_when_not_exist()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new DocumentRepository(_fixture.BuildDbContext(dbName));
            var handler = new DeleteDocumentCommandHandler(repository);


            var command = new DeleteDocumentCommand(DocumentId.CreateUniqueId());



            //act
            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<NotFoundDocumentException>();






        }

    }
}
