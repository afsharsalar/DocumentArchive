namespace DocumentArchive.Application.Categories.CreateCategory;

public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Category.Create(request.Title, true);
        categoryRepository.Create(category);
        await categoryRepository.SaveChangesAsync(cancellationToken);
        return new CreateCategoryCommandResponse(category.Id);
    }
}
