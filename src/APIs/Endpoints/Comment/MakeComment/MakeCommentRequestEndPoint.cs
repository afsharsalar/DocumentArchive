
namespace CommentArchive.APIs.Endpoints.Comment.MakeComment
{
    public class MakeCommentRequestEndPoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/Comments/", async (
                [FromBody] MakeCommentRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<MakeCommentCommand>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map<MakeCommentResponse>(response);
            }).Validator<MakeCommentRequest>()
          .WithTags(EndpointSchema.CommentTag);
        }
    }
}
