using FluentValidation;

namespace PatientApp.UseCases.Authentication.Queries.LoginAuthenticationQuery
{
    public class LoginAuthenticationValidator : AbstractValidator<LoginAuthenticationQuery>
    {
        public LoginAuthenticationValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("User Name cannot be empty");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password cannot be empty");
        }
    }
}
