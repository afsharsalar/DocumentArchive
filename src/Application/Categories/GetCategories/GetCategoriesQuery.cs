namespace DocumentArchive.Application.Categories.GetCategories;

public record GetCategoriesQuery(int Page = 1, int PageSize = 10) : IRequest<IReadOnlyCollection<GetCategoriesQueryResponse>>;
