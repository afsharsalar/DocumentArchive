
using DocumentArchive.Domain.Common;

namespace DocumentArchive.Domain.DocumentAggregator
{
    public class DocumentId : ValueObject<DocumentId>
    {
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public Guid Value { get; init; }

        public static DocumentId CreateUniqueId() => Create(
            Guid.NewGuid()
        );

        public static DocumentId Create(Guid value) => new DocumentId
        {
            Value = value
        };

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
