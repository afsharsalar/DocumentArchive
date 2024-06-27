namespace DocumentArchive.APIs.Endpoints.Category.UpdateCategory
{
    public record UpdateCategoryRequest([FromRoute]Guid CategoryId, string Title,bool IsApprovalNeeded);
}
