namespace DocumentArchive.Application.Categories.GetCategory;

public record GetCategoryQueryResponse(CategoryId CategoryId, string Title, bool IsApprovalNeeded)
{
    public static explicit operator GetCategoryQueryResponse(Category category) => 
        new GetCategoryQueryResponse(
            category.Id,
            category.Title, 
            category.IsApprovalNeeded); 
}
