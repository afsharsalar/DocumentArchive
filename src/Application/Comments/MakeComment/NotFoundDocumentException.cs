

using DocumentArchive.Common.Domain;

namespace DocumentArchive.Application.Comments.MakeComment;

public class NotFoundDocumentException : DomainException
{
    private const string _message = "Article not found.";

    public NotFoundDocumentException() : base(_message)
    {

    }
}
