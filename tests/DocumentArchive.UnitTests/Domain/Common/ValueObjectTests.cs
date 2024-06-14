using DocumentArchive.Domain.Common;
using FluentAssertions;

namespace DocumentArchive.UnitTests.Domain.Common
{
    public class ValueObjectTests
    {
        private class Address : ValueObject<Address>
        {

            public string State { get; init; }
            public string City { get; init; }

            public override IEnumerable<object> GetEqualityComponents()
            {
                yield return State;
                yield return City;
            }
        }

        private class Tag : ValueObject<Address>
        {

            public string Title { get; init; }


            public override IEnumerable<object> GetEqualityComponents()
            {
                yield return Title;
            }
        }

        [Fact]
        public void value_object_off_different_type_should_not_be_equal()
        {
            //arrange
            var valueObjectA = new Address { State = "WA", City = "Urmia" };
            var valueObjectB = new Tag { Title = "Value" };

            //act & assert

            // Act & Assert
            (valueObjectA == valueObjectB).Should().BeFalse();
            (valueObjectA != valueObjectB).Should().BeTrue();

            valueObjectB.Equals(valueObjectA).Should().BeFalse();
            valueObjectA.Equals(valueObjectB).Should().BeFalse();

            (valueObjectA.GetHashCode() == valueObjectB.GetHashCode()).Should().BeFalse();
        }


        [Fact]
        public void value_object_off_same_type_should_not_be_equal_if_have_different_values()
        {
            //arrange
            var a = new Address { State = "WA", City = "Urmia" };
            var b = new Address { State = "Teh", City = "Teh" };

            //act & assert

            a.Should().NotBeEquivalentTo(b);
            (a.GetHashCode() == b.GetHashCode()).Should().BeFalse();
        }
    }
}
