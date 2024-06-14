using DocumentArchive.Domain.CommentAggregator;
using DocumentArchive.Domain.CustomerAggregator;
using DocumentArchive.Domain.DocumentAggregator;
using FluentAssertions;

namespace DocumentArchive.UnitTests.Domain.DocumentAggregator
{
    public class DocumentTests
    {
        [Fact]
        public void create_draft_should_initialize_correctly()
        {
            //arrange
            int userId = 1;
            CustomerId customerId = CustomerId.CreateUniqueId();
            string title = "sample";
            string description = "description";
            //act
            var document = Document.CreateDraft(userId, customerId,null, title, description);

            //assert

            document.Should().NotBeNull();
            document.Id.Should().NotBeNull();
            document.Title.Should().Be(title);
            document.Description.Should().Be(description);
            document.UserId.Should().Be(userId);
            document.CustomerId.Should().Be(customerId);
            document.CategoryId.Should().BeNull();
            document.Status.Should().Be(DocumentStatus.Draft);
            document.ApprovedOnUtc.Should().BeNull();
            document.Tags.Count.Should().Be(0);
            document.CommentIds.Count.Should().Be(0);
            document.CreatedOnUtc.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(2));
        }

        [Fact]
        public void create_should_initialize_correctly()
        {
            //arrange
            int userId = 1;
            CustomerId customerId = CustomerId.CreateUniqueId();
            string title = "sample";
            string description = "description";

            var tags = new List<Tag>
            {
                Tag.Create("aspnetcore") ,
                Tag.Create("dotnet")
            };
            //act
            var document = Document.CreateDocument(userId,customerId,null,title,description,tags);


            document.Should().NotBeNull();
            document.Id.Should().NotBeNull();
            document.Title.Should().Be(title);
            document.Description.Should().Be(description);
            document.UserId.Should().Be(userId);
            document.CustomerId.Should().Be(customerId);
            document.CategoryId.Should().BeNull();
            document.Status.Should().Be(DocumentStatus.Approved);
        
            document.Tags.Count.Should().Be(2);
            document.CommentIds.Count.Should().Be(0);
       
            document.CreatedOnUtc.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(2));
            document.ApprovedOnUtc.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(2));
        }

        [Fact]
        public void approved_draft_document()
        {
            //arrange
            int userId = 1;
            CustomerId customerId = CustomerId.CreateUniqueId();
            string title = "sample";
            string description = "description";

            var document = Document.CreateDraft(userId, customerId, null, title, description);

            //act

            document.Approve();

            //assert

            document.Status.Should().Be(DocumentStatus.Approved);
            document.ApprovedOnUtc.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(2));

        }



        [Fact]
        public void remove_draft_document()
        {
            //arrange
            int userId = 1;
            CustomerId customerId = CustomerId.CreateUniqueId();
            string title = "sample";
            string description = "description";

            var document = Document.CreateDraft(userId, customerId, null, title, description);

            //act

            document.Remove();

            //assert

            document.Status.Should().Be(DocumentStatus.Deleted);
           
        }
    }
}
