using CheckSPNs.Infrastructure.Features.IdentityFeatures.Authentication.Queries.Models;
using FluentValidation;

namespace CheckSPNs.Infrastructure.Features.IdentityFeatures.Authentication.Queries.Validators
{
    public class LoginValidator : AbstractValidator<LoginQuery>
    {
        public LoginValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }

        public void ApplyCustomValidationsRules()
        {

        }
    }
}
