
using DocumentArchive.Common.Domain;

namespace DocumentArchive.Domain.CustomerAggregator
{
    public class CustomerId : ValueObject<CustomerId>
    {
        public Guid Value { get; set; }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static CustomerId CreateUniqueId() => Create(
            Guid.NewGuid()
        );

        public static CustomerId Create(Guid value) => new CustomerId
        {
            Value = value
        };

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
