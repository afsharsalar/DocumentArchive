using DocumentArchive.Application.Categories.CreateCategory;
using DocumentArchive.Domain.CategoryAggregator;

namespace DocumentArchive.APIs.Endpoints.Category.CreateCategory
{
    public class CreateCategoryMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<CreateCategoryRequest, CreateCategoryCommand>();
            config.ForType<CreateCategoryCommandResponse, CreateCategoryResponse>()
               .Map(p => p.CategoryId, src => src.CategoryId.Value);
        }
    }
}
