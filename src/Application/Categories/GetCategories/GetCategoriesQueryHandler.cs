namespace DocumentArchive.Application.Categories.GetCategories;

public class GetCategoriesQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoriesQuery, IReadOnlyCollection<GetCategoriesQueryResponse>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    public  async Task<IReadOnlyCollection<GetCategoriesQueryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetPaged(request.Page, request.PageSize, cancellationToken);
        return [.. categories.Select(x => (GetCategoriesQueryResponse)x)];
    }
}
