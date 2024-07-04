﻿using CheckSPNs.Domain.Exceptions;

namespace CheckSPNs.Infrastructure.Exceptions;

public class ValidationException : DomainException
{
    public ValidationException(IReadOnlyCollection<ValidationError> errors)
        : base("Validation Failure", "One or more validation failures have occurred.")
    {
        Errors = errors;
    }

    public IReadOnlyCollection<ValidationError> Errors { get; }
}

public record ValidationError(string PropertyName, string ErrorMessage);
