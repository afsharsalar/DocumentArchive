namespace DocumentArchive.Application.Categories.UpdateCategory
{
    public record UpdateCategoryCommand(CategoryId CategoryId, string Title, bool IsApprovalNeeded) : IRequest<UpdateCategoryCommandResponse>;
}
