﻿using DocumentArchive.Common.Domain;

namespace DocumentArchive.Domain.CategoryAggregator
{
    public class Category : BaseAggregateRoot<CategoryId>
    {
        public Category(CategoryId id) : base(id)
        {
        }
        private Category() : this(null!) { }

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

        public void UpdateCategory(string title, bool isApprovalNeeded)
        {
            Title = title;
            IsApprovalNeeded = isApprovalNeeded;
        }
    }
}
