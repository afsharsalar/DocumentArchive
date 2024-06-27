namespace DocumentArchive.APIs.Endpoints.Customer.CreateCustomer
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {

            RuleFor(p=>p.Title).NotEmpty()
                .NotNull();

            RuleFor(p => p.PostalCode)
                .MaximumLength(10);
        }
    }
}
