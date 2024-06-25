namespace CategoryArchive.APIs.Endpoints.Category.GetCategory
{
    public record GetCategoriesResponse
        (Guid Id,
        string Title,
        bool IsApprovalNeeded);
}
