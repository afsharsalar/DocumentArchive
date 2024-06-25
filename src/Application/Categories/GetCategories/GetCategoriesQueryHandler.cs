namespace DocumentArchive.Application.Categories.GetCategories;

public class GetCategoriesQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoriesQuery, IReadOnlyCollection<GetCategoriesQueryResponse>>
{
    
    public  async Task<IReadOnlyCollection<GetCategoriesQueryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetPaged(request.Page, request.PageSize, cancellationToken);
        return [.. categories.Select(x => (GetCategoriesQueryResponse)x)];
    }
}
