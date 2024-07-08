

using DocumentArchive.Application.Categories.GetCategories;

namespace App.Models.Category;

public class GetCategoriesMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
       
            

        config.ForType<GetCategoriesQueryResponse, GetCategoriesResponse>()
             .Map(p => p.Id, src => src.CategoryId.Value);
    }
}
