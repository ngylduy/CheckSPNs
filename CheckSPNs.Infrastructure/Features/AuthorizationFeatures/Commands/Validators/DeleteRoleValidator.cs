using CheckSPNs.Service.EF.Abstract;
using FluentValidation;
using SchoolProject.Core.Features.Authorization.Commands.Models;

namespace SchoolProject.Core.Features.Authorization.Commands.Validators
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {
        public readonly IAuthorizationService _authorizationService;

        public DeleteRoleValidator(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                 .NotEmpty()
                 .NotNull();
        }
        public void ApplyCustomValidationsRules()
        {
            //RuleFor(x => x.Id)
            //    .MustAsync(async (Key, CancellationToken) => await _authorizationService.IsRoleExistById(Key))
            //    .WithMessage(_stringLocalizer[SharedResourcesKeys.RoleNotExist]);
        }
    }
}
