using System.Collections.Immutable;

namespace DocumentArchive.Domain.Common
{
    public abstract class BaseAggregateRoot<TId>: BaseEntity<TId>,IAggregateRoot
    {
        private readonly IList<IDomainEvent> _events;
        public IReadOnlyCollection<IDomainEvent> Events => _events.ToImmutableArray();


        protected BaseAggregateRoot(TId id) : base(id)
        {
            _events = new List<IDomainEvent>();
        }

        public void ClearEvents() => _events.Clear();

        protected void AddEvent<TDomainEvent>(TDomainEvent @event) where TDomainEvent : IDomainEvent =>
            _events.Add(@event);

    }
}
