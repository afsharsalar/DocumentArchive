namespace DocumentArchive.APIs.Endpoints.Comment.MakeComment;

public class MakeCommentRequestValidator : AbstractValidator<MakeCommentRequest>
{
    public MakeCommentRequestValidator()
    {
        RuleFor(p => p.Content)
           .NotEmpty()
           .NotNull()
           .MaximumLength(512);

    }
}
