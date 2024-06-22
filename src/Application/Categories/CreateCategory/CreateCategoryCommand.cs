namespace DocumentArchive.Application.Categories.CreateCategory;

public record CreateCategoryCommand(string Title):IRequest<CreateCategoryCommandResponse>;
