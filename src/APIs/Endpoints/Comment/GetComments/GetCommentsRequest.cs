namespace DocumentArchive.APIs.Endpoints.Comment.GetComments
{
    public record GetCommentsRequest([FromRoute]Guid DocumentId);
    
}
