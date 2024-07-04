using CheckSPNs.Infrastructure.Features.ReportFeatures.Commands.Models;
using CheckSPNs.Service.EF.Abstract;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CheckSPNs.Infrastructure.Features.ReportFeatures.Commands.Validators
{
    public class AddReportValidator : AbstractValidator<AddReportCommand>
    {
        public AddReportValidator(ITypeOfReportService typeOfReportService)
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

            RuleFor(x => x.Comment)
                 .NotEmpty()
                 .NotNull()
                 .MinimumLength(10).WithMessage("Report must not be less than 10 characters.");
        }

        public void ApplyCustomValidationsRules()
        {

        }
    }
}
