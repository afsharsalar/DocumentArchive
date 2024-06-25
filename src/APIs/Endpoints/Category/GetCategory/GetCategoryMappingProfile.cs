
using DocumentArchive.Application.Categories.GetCategory;
using DocumentArchive.Domain.CategoryAggregator;

namespace CategoryArchive.APIs.Endpoints.Category.GetCategory;

public class GetCategoryMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetCategoryRequest, GetCategoryQuery>()
            .Map(p=>p.CategoryId,src=>CategoryId.Create(src.CategoryId));

        config.ForType<GetCategoryQueryResponse, GetCategoryResponse>()
             .Map(p => p.Id, src => src.CategoryId.Value);
    }
}
