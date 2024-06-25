using DocumentArchive.Application.Categories.GetCategories;
using DocumentArchive.Domain.CategoryAggregator;
using DocumentArchive.Infrastructure.Persistence.Repositories;
using DocumentArchive.IntegrationTests.Fixtures;

using System.Threading.Tasks;

using System.Threading;

using System;
using DocumentArchive.Application.Documents.GetDocuments;
using DocumentArchive.Domain.DocumentAggregator;
using DocumentArchive.Domain.CustomerAggregator;
using FluentAssertions;

namespace DocumentArchive.IntegrationTests.Documents
{
    public class GetDocumentsQueryHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public GetDocumentsQueryHandlerTests(DbContextFixture fixture)
        {

            _fixture = fixture;

        }



        [Fact]
        public async Task should_return_expected_data()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new DocumentRepository(_fixture.BuildDbContext(dbName));
            var handler = new GetDocumentsQueryHandler(repository);
            var query = new GetDocumentsQuery();

            var count = 20;

            for (var i = 1; i <= count; i++)
            {
                repository.Create(Document.CreateDocument(1,
                    CustomerId.CreateUniqueId(),
                    CategoryId.CreateUniqueId(),
                    "Title",
                    "Desc",
                    [Tag.Create("Tag1")]));
            }



            await repository.SaveChangesAsync(CancellationToken.None);

            //act
            var result = await handler.Handle(query, CancellationToken.None);

            result.Should().NotBeNull();
            result.Count.Should().Be(query.PageSize);

        }
    }
}
