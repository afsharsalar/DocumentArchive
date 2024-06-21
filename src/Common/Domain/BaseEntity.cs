namespace DocumentArchive.Common.Domain
{
    public abstract class BaseEntity<TId> where TId :notnull
    {
        public TId Id { get; protected set; }

        protected BaseEntity(TId id)
        {
            Id = id;
        }


        public override bool Equals(object? obj)
        {
            var entity=obj as BaseEntity<TId>;
            
            if(entity is null) return false;
            if (entity.GetType() != this.GetType()) return false;

            return EqualityComparer<TId>.Default.Equals(Id,entity.Id);
        }

        public static bool operator == (BaseEntity<TId>? left, BaseEntity<TId>? right)
        {
            if (ReferenceEquals(left, right)) return true;

            if (left is null || right is null) return false;

            return left.Equals(right);
        }

        public static bool operator != (BaseEntity<TId>? left, BaseEntity<TId>? right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.GetType(),Id);
        }
    }

   
}
