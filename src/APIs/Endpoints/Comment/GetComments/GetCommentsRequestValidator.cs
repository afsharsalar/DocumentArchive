namespace DocumentArchive.APIs.Endpoints.Comment.GetComments
{
    public class GetCommentsRequestValidator : AbstractValidator<GetCommentsRequest>
    {
        public GetCommentsRequestValidator()
        {
            RuleFor(x => x.DocumentId)
                .NotEmpty()
                .NotNull();
        }
    }
}
