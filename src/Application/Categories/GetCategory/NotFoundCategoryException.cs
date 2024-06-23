using DocumentArchive.Common.Domain;

namespace DocumentArchive.Application.Categories.GetCategory;

public class NotFoundCategoryException : DomainException
{
    private const string _message = "Category not found.";
    public NotFoundCategoryException() : base(_message)
    {
        
    }
}
