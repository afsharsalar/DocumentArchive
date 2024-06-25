namespace DocumentArchive.APIs.Endpoints.Category.UpdateCategory
{
    public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryRequestValidator()
        {
            RuleFor(p => p.Title)
               .NotEmpty()
               .NotNull()
               .MaximumLength(256);
        }
    }
}
