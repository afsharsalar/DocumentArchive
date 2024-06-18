using DocumentArchive.Domain.CategoryAggregator;
using DocumentArchive.Domain.CommentAggregator;
using DocumentArchive.Domain.Common;
using DocumentArchive.Domain.CustomerAggregator;

namespace DocumentArchive.Domain.DocumentAggregator;

public class Document : BaseAggregateRoot<DocumentId>
{
    public Document(DocumentId id) : base(id)
    {
        _tags=new List<Tag>();
        _commentIds=new List<CommentId>();
    }

    private Document() : this(null!) { }

    public CategoryId CategoryId { get; set; }

    public CustomerId CustomerId { get; set; }

    public int UserId { get; set; }
    public string Title { get; private set; } = null;

    public string Description { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? ApprovedOnUtc { get; private set; }

    public DocumentStatus Status { get; set; }

    private readonly List<Tag> _tags = null!;
    public IReadOnlyCollection<Tag> Tags =>  _tags;


    private readonly List<CommentId> _commentIds = null!;
    public IReadOnlyCollection<CommentId> CommentIds => _commentIds;


    public static Document CreateDraft(int userId,CustomerId customerId,CategoryId categoryId, string title, string description)
    {
        return new Document(DocumentId.CreateUniqueId())
        {
            UserId = userId,
            CustomerId = customerId,
            CategoryId = categoryId,
            Title = title,
            Description =   description,
            Status = DocumentStatus.Draft,
            CreatedOnUtc = DateTime.UtcNow
        };
    }

    public static Document CreateDocument(int userId, CustomerId customerId, CategoryId categoryId, string title, string description,IReadOnlyList<Tag> tags)
    {
        var document = CreateDraft(userId,customerId,categoryId, title, description);

        document.AddTags(tags);
        document.Approve();

        return document;
    }

    

    private void AddTags(IReadOnlyList<Tag> tags)
    {
        _tags.AddRange(tags);
    }


    public void UpdateTags(IReadOnlyList<Tag> tags)
    {
        if(_tags is not null)
            _tags.Clear();
        AddTags(tags);
    }


    public void Approve()
    {
        Status = DocumentStatus.Approved;
        ApprovedOnUtc= DateTime.UtcNow;
    }

    public void Remove()
    {
        Status= DocumentStatus.Deleted;
    }
}