﻿using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Infrastructure.Shared.Validation;
using FluentValidation;
using MediatR;

namespace CheckSPNs.Infrastructure.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{

    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var validationResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(request, cancellationToken)));
            Error[] errors = validationResults
                .SelectMany(x => x.Errors)
                .Where(x => x is not null)
                .Select(x => new Error(x.PropertyName, x.ErrorMessage))
                .Distinct()
                .ToArray();
            if (errors.Any())
            {
                return CreateValidationResult<TResponse>(errors);
            }
        }
        return await next();
    }

    private static TResult CreateValidationResult<TResult>(Error[] errors)
        where TResult : Result
    {
        if (typeof(TResult) == typeof(Result))
        {
            return (ValidationResult.WithErrors(errors) as TResult)!;
        }

        object validationResult = typeof(ValidationResult<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
            .GetMethod(nameof(ValidationResult.WithErrors))!
            .Invoke(null, new object?[] { errors })!;

        return (TResult)validationResult;
    }
}
