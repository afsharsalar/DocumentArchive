namespace DocumentArchive.Common.Domain
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
