using DocumentArchive.Domain.CategoryAggregator;

using FluentAssertions;

namespace DocumentArchive.UnitTests.Domain.CategoryAggregator
{
    public class CategoryTests
    {
        [Fact]
        public void create_should_initialize_correctly()
        {
            //arrange
            bool isApprovalNeeded=false;
            var title = "sample";

            //act
            var category = Category.Create(title, isApprovalNeeded);

            //assert

            category.Should().NotBeNull();
            category.Title.Should().Be(title);
            category.IsApprovalNeeded.Should().Be(isApprovalNeeded);
            category.Id.Should().NotBeNull();
        }
    }
}
