using FluentValidation;
using SchoolProject.Core.Features.Authorization.Commands.Models;

namespace SchoolProject.Core.Features.Authorization.Commands.Validators
{
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {
        public EditRoleValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                 .NotEmpty()
                 .NotNull();

            RuleFor(x => x.Name)
                 .NotEmpty()
                 .NotNull();
        }

        public void ApplyCustomValidationsRules()
        {

        }
    }
}
