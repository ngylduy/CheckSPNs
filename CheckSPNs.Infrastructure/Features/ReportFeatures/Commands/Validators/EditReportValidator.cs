using CheckSPNs.Infrastructure.Features.ReportFeatures.Commands.Models;
using CheckSPNs.Service.EF.Abstract;
using FluentValidation;

namespace CheckSPNs.Infrastructure.Features.ReportFeatures.Commands.Validators
{
    public class EditReportValidator : AbstractValidator<EditReportCommand>
    {
        public EditReportValidator(ITypeOfReportService typeOfReportService)
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        public void ApplyValidationsRules()
        {
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
