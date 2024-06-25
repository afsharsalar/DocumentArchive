using DocumentArchive.Application.Categories.GetCategory;

namespace DocumentArchive.Application.Categories.UpdateCategory;

public class UpdateCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
{
    private readonly ICategoryRepository _categoryRepository=categoryRepository;
    public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category =await _categoryRepository.GetById(request.CategoryId, cancellationToken);
        if (category == null) { throw new NotFoundCategoryException(); }
        category.UpdateCategory(request.Title, request.IsApprovalNeeded);
        //_categoryRepository.Update(category);
        await _categoryRepository.SaveChangesAsync(cancellationToken);
        return new UpdateCategoryCommandResponse(category.Id);
    }
}
