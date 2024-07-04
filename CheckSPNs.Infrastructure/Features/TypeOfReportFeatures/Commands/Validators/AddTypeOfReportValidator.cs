using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Commands.Models;
using CheckSPNs.Service.EF.Abstract;
using FluentValidation;

namespace CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Commands.Validators
{
    public class AddTypeOfReportValidator : AbstractValidator<AddTypeOfReportCommand>
    {
        private readonly ITypeOfReportService _typeOfReportService;

        public AddTypeOfReportValidator(ITypeOfReportService typeOfReportService)
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
                .MustAsync(async (model, Key, CancellationToken) => !await _typeOfReportService.IsTypeOfReportExit(model.TypeOfReport))
                .WithMessage("Type of Report is exited!");
        }
    }
}
