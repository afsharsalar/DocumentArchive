using DocumentArchive.Domain.Common;

namespace DocumentArchive.Domain.CategoryAggregator
{
    public class CategoryId : ValueObject<CategoryId>
    {
        public Guid Value { get; set; }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static CategoryId CreateUniqueId() => Create(
            Guid.NewGuid()
        );

        public static CategoryId Create(Guid value) => new CategoryId
        {
            Value = value
        };
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
