using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentArchive.Domain.CommentAggregator;
using DocumentArchive.Domain.DocumentAggregator;
using FluentAssertions;

namespace DocumentArchive.UnitTests.Domain.CommentAggregator
{
    public class CommentTests
    {

        [Fact]
        public void create_should_initialize_correctly()
        {
            //arrange
            var documentId = DocumentId.CreateUniqueId();
            var userId = 1;
            var content = "";


            //act
          
            var comment = Comment.Create(documentId, userId, content);

            //assert

            comment.Should().NotBeNull();
            comment.DocumentId.Should().Be(documentId);
            comment.UserId.Should().Be(userId);
            comment.Content.Should().Be(content);
            comment.CreatedOnUtc.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(2));
            
        }
    }
}
