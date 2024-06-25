namespace DocumentArchive.APIs.Endpoints.Category.CreateCategory
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(p => p.Title)
               .NotEmpty()
               .NotNull()
               .MaximumLength(256);
        }
    }
}
