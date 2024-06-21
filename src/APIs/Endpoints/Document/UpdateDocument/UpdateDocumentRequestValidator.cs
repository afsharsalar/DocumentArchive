
namespace DocumentArchive.APIs.Endpoints.Document.UpdateDocument;

public class UpdateDocumentRequestValidator : AbstractValidator<UpdateDocumentRequest>
{
    public const string TagMaximumLengthMessage = "تعداد کاراکتر های تگ بیشتر از حد مجاز است";
    public UpdateDocumentRequestValidator()
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
