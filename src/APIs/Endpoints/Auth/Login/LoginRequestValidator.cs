namespace DocumentArchive.APIs.Endpoints.Auth.Login
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(p => p.Username).NotEmpty().NotNull();
            RuleFor(p => p.Password).NotEmpty().NotNull();
        }
    }
}
