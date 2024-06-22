namespace DocumentArchive.APIs.Endpoints.Comment.GetComments
{
    public record GetCommentsResponse(string DisplayName,DateTime CreatedOnUtc,string Content);
    
}
