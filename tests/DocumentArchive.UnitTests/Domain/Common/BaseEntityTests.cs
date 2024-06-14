using DocumentArchive.Domain.Common;
using FluentAssertions;

namespace DocumentArchive.UnitTests.Domain.Common
{

    public class BaseEntityTests
    {
        private class User : BaseEntity<int>
        {
            public User(int id) : base(id)
            {
                Id = id;
            }
        }

        public class Customer : BaseEntity<int>
        {
            public Customer(int id):base(id)
            {
                Id = id;
            }
        }


        [Fact]
        public void entity_of_diff_types_should_not_be_equal_when_ids_are_equal()
        {
            //arrange
            var id = 10;
            var entity1 = new User(id);
            var entity2 = new Customer(id);


            //act & assert

            entity1.Should().NotBeEquivalentTo(entity2);
            (entity2 == entity1).Should().BeFalse();
            (entity2.GetHashCode() == entity1.GetHashCode()).Should().BeFalse();
        }


        [Fact]
        public void entity_of_same_type_should_be_equal_when_ids_are_equal()
        {
            //arrange
            var id = 10;
            var entity1 = new User(id);
            var entity2 = new User(id);


            //act & assert

            entity1.Should().BeEquivalentTo(entity2);
            (entity2 == entity1).Should().BeTrue();
        }

        [Fact]
        public void entity_of_same_type_should_be_not_equal_when_ids_are_different()
        {
            //arrange
            var entity1 = new User(10);
            var entity2 = new User(11);


            //act & assert

            entity1.Should().NotBeEquivalentTo(entity2);
            (entity2 != entity1).Should().BeTrue();
        }
    }
}
