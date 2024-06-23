namespace DocumentArchive.Application.Categories.GetCategories;

public record GetCategoriesQueryResponse(
    CategoryId CategoryId, 
    string Title, 
    bool IsApprovalNeeded)
{
    public static explicit operator GetCategoriesQueryResponse(Category category) =>
   new GetCategoriesQueryResponse(
       category.Id,
       category.Title,
       category.IsApprovalNeeded);
}
