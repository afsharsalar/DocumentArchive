namespace CategoryArchive.APIs.Endpoints.Category.GetCategory
{
    public record GetCategoryResponse
        (string Id,
        string Title,
        bool IsApprovalNeeded);
}
