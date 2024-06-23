
namespace DocumentArchive.Application.Categories.GetCategory
{
    public class GetCategoryQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoryQuery, GetCategoryQueryResponse>
    {
        private readonly ICategoryRepository _categoryRepository=categoryRepository;
        public async Task<GetCategoryQueryResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(request.CategoryId, cancellationToken);
            if(category == null) { throw new NotFoundCategoryException(); }
            return (GetCategoryQueryResponse)category;
        }
    }
}
