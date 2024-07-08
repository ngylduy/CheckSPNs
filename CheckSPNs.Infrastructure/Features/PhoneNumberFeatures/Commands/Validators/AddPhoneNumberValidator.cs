using CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Commands.Models;
using FluentValidation;

namespace CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Commands.Validators
{
    public class AddPhoneNumberValidator : AbstractValidator<ReportPhoneNumberCommand>
    {
        public AddPhoneNumberValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .WithMessage("Phone Number is required.")
                .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
                .MaximumLength(12).WithMessage("PhoneNumber must not exceed 12 characters.");
        }

        public void ApplyCustomValidationsRules()
        {

        }
    }
}
