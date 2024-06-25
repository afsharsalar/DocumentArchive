
using CategoryArchive.APIs.Endpoints.Category.GetCategory;

using DocumentArchive.APIs.Endpoints.Category.GetCategories;
using DocumentArchive.Application.Categories.GetCategories;


namespace CategoriesArchive.APIs.Endpoints.Categories.GetCategories;

public class GetCategoriesMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetCategoriesRequest, GetCategoriesQuery>();
            

        config.ForType<GetCategoriesQueryResponse, GetCategoriesResponse>()
             .Map(p => p.Id, src => src.CategoryId.Value);
    }
}
