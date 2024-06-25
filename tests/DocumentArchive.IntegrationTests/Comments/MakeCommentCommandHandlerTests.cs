using DocumentArchive.Application.Comments.MakeComment;
using DocumentArchive.Domain.CategoryAggregator;
using DocumentArchive.Domain.CustomerAggregator;
using DocumentArchive.Domain.DocumentAggregator;
using DocumentArchive.Infrastructure.Persistence.Repositories;
using DocumentArchive.IntegrationTests.Fixtures;

using FluentAssertions;

using System;
using System.Threading;
using System.Threading.Tasks;

using Document = DocumentArchive.Domain.DocumentAggregator.Document;

namespace DocumentArchive.IntegrationTests.Comments
{
    public class MakeCommentCommandHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public MakeCommentCommandHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture; 
        }


        [Fact]
        public async Task  should_make_comment_if_document_exist()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new CommentRepository(_fixture.BuildDbContext(dbName));
            var documentRepository=new DocumentRepository(_fixture.BuildDbContext(dbName));

            var handler = new MakeCommentCommandHandler(repository, documentRepository);

            int userId = 1;

            var document=Document.CreateDocument(
                userId,
                CustomerId.CreateUniqueId(),
                CategoryId.CreateUniqueId(),
                "title 1",
                "desc",
                [Tag.Create("Tag1"), Tag.Create("Tag2")]);


            documentRepository.Create(document);
            await documentRepository.SaveChangesAsync(CancellationToken.None);


            var command = new MakeCommentCommand(document.Id,userId, "Category 1");

            //act
            var response =await  handler.Handle(command,CancellationToken.None);


            response.Should().NotBeNull();

        }



        [Fact]
        public async Task should_throw_exception_if_document_exist()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repository = new CommentRepository(_fixture.BuildDbContext(dbName));
            var documentRepository = new DocumentRepository(_fixture.BuildDbContext(dbName));

            var handler = new MakeCommentCommandHandler(repository, documentRepository);

            int userId = 1;


            var command = new MakeCommentCommand(DocumentId.CreateUniqueId(), userId, "Category 1");

            //act
            Func<Task> act = async()=> await handler.Handle(command, CancellationToken.None);


            await act.Should().ThrowAsync<NotFoundDocumentException>();

        }
    }
}
