namespace DocumentArchive.APIs.Endpoints.Customer.UpdateCustomer
{
    public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerRequestValidator()
        {
            RuleFor(p => p.Title).NotEmpty()
              .NotNull();

            RuleFor(p => p.PostalCode)
                .MaximumLength(10);
        }
    }
}
