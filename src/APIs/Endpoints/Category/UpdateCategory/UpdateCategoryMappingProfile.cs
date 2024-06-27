using DocumentArchive.Application.Categories.UpdateCategory;
using DocumentArchive.Domain.CategoryAggregator;

namespace DocumentArchive.APIs.Endpoints.Category.UpdateCategory
{
    public class UpdateCategoryMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<UpdateCategoryRequest, UpdateCategoryCommand>()
                .Map(p => p.CategoryId, src => CategoryId.Create(src.CategoryId));


            config.ForType<UpdateCategoryCommandResponse, UpdateCategoryResponse>()
                .Map(p => p.CategoryId, src => src.CategoryId.Value);
        }
    }
}
