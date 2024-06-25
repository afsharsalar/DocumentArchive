namespace DocumentArchive.APIs.Endpoints.Category.UpdateCategory
{
    public record UpdateCategoryRequest(Guid CategoryId, string Title,bool IsApprovalNeeded);
}
