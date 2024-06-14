using DocumentArchive.Domain.Common;
using DocumentArchive.Domain.DocumentAggregator;

namespace DocumentArchive.Domain.CommentAggregator
{
    public class Comment : BaseAggregateRoot<CommentId>
    {
        public Comment(CommentId id) : base(id)
        {
        }

        public int UserId { get; set; }
        public DocumentId DocumentId { get; set; } = null;
        public string Content { get; set; }
        public DateTime CreatedOnUtc { get; init; }



        public static Comment Create(DocumentId documentId,int userId, string content)
        {
            return new Comment(CommentId.CreateUniqueId())
            {
                DocumentId = documentId,
                UserId = userId,
                Content = content,
                CreatedOnUtc = DateTime.UtcNow
            };
        }
    }
}
