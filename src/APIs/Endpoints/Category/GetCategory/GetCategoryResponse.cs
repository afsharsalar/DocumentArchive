namespace CategoryArchive.APIs.Endpoints.Category.GetCategory
{
    public record GetCategoryResponse
        (Guid Id,
        string Title,
        bool IsApprovalNeeded);
}
