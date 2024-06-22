namespace DocumentArchive.Application.Categories.GetCategory;

public record GetCategoryQuery(CategoryId CategoryId):IRequest<GetCategoryQueryResponse>;
