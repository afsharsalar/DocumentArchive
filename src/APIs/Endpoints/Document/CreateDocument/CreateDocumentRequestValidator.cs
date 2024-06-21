namespace DocumentArchive.APIs.Endpoints.Document.CreateDocument
{
    public class CreateDocumentRequestValidator : AbstractValidator<CreateDocumentRequest>
    {
        public const string TagMaximumLengthMessage = "تعداد کاراکتر های تگ بیشتر از حدف مجاز است";

        public CreateDocumentRequestValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(512);


            RuleFor(p => p.Description)
                .MaximumLength(2048);


            RuleFor(x => x.Tags)            
                .Must(x => x.Length <= 10)
                .WithMessage(TagMaximumLengthMessage);
        }

    }
}
