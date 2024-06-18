
namespace DocumentArchive.Application.Exceptions
{
    [Serializable]
    public class NotFoundDocumentException : Exception
    {
        private const string _message = "Document not found";
        public NotFoundDocumentException() : base(_message)
        {
        }

    
    }
}