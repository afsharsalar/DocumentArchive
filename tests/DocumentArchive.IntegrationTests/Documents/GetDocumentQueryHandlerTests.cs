using DocumentArchive.Application.Comments.MakeComment;
using DocumentArchive.Application.Documents.GetDocument;
using DocumentArchive.Domain.CategoryAggregator;
using DocumentArchive.Domain.CustomerAggregator;
using DocumentArchive.Domain.DocumentAggregator;
using DocumentArchive.Infrastructure.Persistence.Repositories;
using DocumentArchive.IntegrationTests.Fixtures;

using FluentAssertions;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentArchive.IntegrationTests.Documents
{
    public class GetDocumentQueryHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;

        public GetDocumentQueryHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task should_return_expected_result()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new DocumentRepository(_fixture.BuildDbContext(dbName));
            var handler = new GetDocumentQueryHandler(repository);


            int userId = 1;

            var document = Document.CreateDocument(userId, CustomerId.CreateUniqueId(),
                CategoryId.CreateUniqueId(),
                "title",
                "description",
                [Tag.Create("Tag1"), Tag.Create("Tag2"), Tag.Create("Tag3")]);

            repository.Create(document);
            await repository.SaveChangesAsync(CancellationToken.None);

            var query = new GetDocumentQuery(document.Id);

            //act

            var response = await handler.Handle(query, CancellationToken.None);

            response.Should().NotBeNull();
            response?.Title.Should().Be(document.Title);
            response?.Description.Should().Be(document.Description);
            response?.Tags.Count.Should().Be(3);

        }

        [Fact]
        public async Task should_throw_exception_if_not_exist()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new DocumentRepository(_fixture.BuildDbContext(dbName));
            var handler = new GetDocumentQueryHandler(repository);


            var query = new GetDocumentQuery(DocumentId.CreateUniqueId());

            //act

            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);

            await act.Should().ThrowAsync<NotFoundDocumentException>();

        }
    }
}
