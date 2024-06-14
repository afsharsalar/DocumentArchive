using DocumentArchive.Domain.Common;

namespace DocumentArchive.Domain.CategoryAggregator
{
    public class Category : BaseAggregateRoot<CategoryId>
    {
        public Category(CategoryId id) : base(id)
        {
        }

        public string Title { get; set; }

        public bool IsApprovalNeeded { get; set; }


        public static Category Create(string title,bool isApprovalNeeded)
        {
            return new Category(CategoryId.CreateUniqueId())
            {
                IsApprovalNeeded = isApprovalNeeded,
                Title = title
            };
        }
    }
}
