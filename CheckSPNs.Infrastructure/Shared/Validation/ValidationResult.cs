using CheckSPNs.Service.Application.Shared;

namespace CheckSPNs.Infrastructure.Shared.Validation;

public class ValidationResult : Result, IValidationResult
{
    private ValidationResult(Error[] errors) : base(false, IValidationResult.ValidationError)
    {
        Errors = errors;
    }

    public Error[] Errors { get; }

    public static ValidationResult WithError(Error[] errors)
    {
        return new(errors);
    }
}
