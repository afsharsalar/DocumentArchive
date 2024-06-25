namespace DocumentArchive.APIs.Endpoints.Comment.GetComments
{
    public record GetCommentsRequest([FromRoute]Guid DocumentId, int Page = 1, int PageSize = 10);
    
}
