namespace DocumentArchive.APIs.Endpoints.Category.UpdateCategory
{
    public record UpdateCategoryResponse(Guid CategoryId, string Title,bool IsApprovalNeeded);
}
