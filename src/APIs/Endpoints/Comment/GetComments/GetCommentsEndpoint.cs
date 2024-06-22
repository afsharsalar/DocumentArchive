﻿using DocumentArchive.Application.Comments.GetComments;

namespace DocumentArchive.APIs.Endpoints.Comment.GetComments
{
    public class GetCommentsEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/Comments/{documentId}", async (
                [AsParameters] GetCommentsRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GetCommentsQuery>(request);
                var result = await mediator.Send(command, cancellationToken);

                return mapper.Map<GetCommentsResponse>(result);
            }).Validator<GetCommentsRequest>()
        .WithTags(EndpointSchema.CommentTag);
        }
    }
}
