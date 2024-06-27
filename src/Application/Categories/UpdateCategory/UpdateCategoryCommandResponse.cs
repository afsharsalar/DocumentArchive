namespace DocumentArchive.Application.Categories.UpdateCategory
{
    public record UpdateCategoryCommandResponse(CategoryId CategoryId, string Title, bool IsApprovalNeeded)
    {
        public static explicit operator UpdateCategoryCommandResponse(Category category) =>
            new UpdateCategoryCommandResponse(category.Id,category.Title,category.IsApprovalNeeded  );
    }
}
