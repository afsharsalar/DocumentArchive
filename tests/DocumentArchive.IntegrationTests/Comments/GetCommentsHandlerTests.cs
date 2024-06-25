using DocumentArchive.Application.Comments.GetComments;
using DocumentArchive.Domain.CategoryAggregator;
using DocumentArchive.Domain.CommentAggregator;
using DocumentArchive.Domain.CustomerAggregator;
using DocumentArchive.Domain.DocumentAggregator;
using DocumentArchive.Infrastructure.Persistence.Repositories;
using DocumentArchive.IntegrationTests.Fixtures;

using FluentAssertions;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentArchive.IntegrationTests.Comments
{
    public class GetCommentsHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public GetCommentsHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture;
        }


        [Fact]
        public async Task should_return_comments()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new CommentRepository(_fixture.BuildDbContext(dbName));
          
            var handler = new GetCommentsHandler(repository);
            
            int userId = 1;

            var document = Document.CreateDocument(
               userId,
               CustomerId.CreateUniqueId(),
               CategoryId.CreateUniqueId(),
               "title 1",
               "desc",
               [Tag.Create("Tag1"), Tag.Create("Tag2")]);

            var documentRepository = new DocumentRepository(_fixture.BuildDbContext(dbName));

            documentRepository.Create(document);
            await documentRepository.SaveChangesAsync(CancellationToken.None);


            var comment = Comment.Create(document.Id, userId, "Content1");
            await repository.CreateAsync(comment, CancellationToken.None);
            await repository.SaveChangesAsync(CancellationToken.None);

            //act

            var response=await handler.Handle(new GetCommentsQuery(document.Id),CancellationToken.None);

            response.Should().NotBeNull();

            response.Count.Should().Be(1);

        }
    }
}
