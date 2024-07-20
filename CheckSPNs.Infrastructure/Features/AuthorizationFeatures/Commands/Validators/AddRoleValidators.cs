using CheckSPNs.Service.EF.Abstract;
using FluentValidation;
using SchoolProject.Core.Features.Authorization.Commands.Models;

namespace SchoolProject.Core.Features.Authorization.Commands.Validators
{
    public class AddRoleValidators : AbstractValidator<AddRoleCommand>
    {
        private readonly IAuthorizationService _authorizationService;

        public AddRoleValidators(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.RoleName)
                 .NotEmpty()
                 .NotNull();
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.RoleName)
                .MustAsync(async (Key, CancellationToken) => !await _authorizationService.IsRoleExistByName(Key));
        }

    }
}
