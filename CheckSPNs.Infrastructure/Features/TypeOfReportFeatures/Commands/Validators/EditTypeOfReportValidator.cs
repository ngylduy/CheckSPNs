using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Commands.Models;
using CheckSPNs.Service.EF.Abstract;
using FluentValidation;

namespace CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Commands.Validators
{
    public class EditTypeOfReportValidator : AbstractValidator<EditTypeOfReportCommand>
    {
        private readonly ITypeOfReportService _typeOfReportService;

        public EditTypeOfReportValidator(ITypeOfReportService typeOfReportService)
        {
            _typeOfReportService = typeOfReportService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.TypeOfReport)
                 .NotEmpty()
                 .NotNull()
                 .MaximumLength(100);
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.TypeOfReport)
                .MustAsync(async (model, Key, CancellationToken) => !await _typeOfReportService.IsTypeOfReportExitExcludeSelf(model.TypeOfReport, model.Id));
        }
    }
}
