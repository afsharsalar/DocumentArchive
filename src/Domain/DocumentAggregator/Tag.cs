using DocumentArchive.Common.Domain;
using Humanizer;

namespace DocumentArchive.Domain.DocumentAggregator
{
    public class Tag : ValueObject<Tag>
    {
        public string Value { get; set; } = null;
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }


        public static Tag Create(string value)
        {
            return new Tag()
            {
                Value = value.Kebaberize()
            };
        }


        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
