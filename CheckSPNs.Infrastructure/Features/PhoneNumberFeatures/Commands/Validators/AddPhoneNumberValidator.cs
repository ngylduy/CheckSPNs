using CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Commands.Models;
using FluentValidation;
using System.Text.RegularExpressions;

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
                .MaximumLength(12).WithMessage("PhoneNumber must not exceed 12 characters.")
                .Matches(new Regex(@"0(1\d{9}|9\d{8})")).WithMessage("PhoneNumber not valid");
        }

        public void ApplyCustomValidationsRules()
        {

        }
    }
}
