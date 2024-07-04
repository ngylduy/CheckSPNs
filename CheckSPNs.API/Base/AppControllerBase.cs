using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Infrastructure.Shared.Validation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CheckSPNs.API.Base;

[ApiController]
public class AppControllerBase : ControllerBase
{
    protected readonly ISender Sender;

    protected AppControllerBase(ISender sender) => Sender = sender;

    protected IActionResult HandlerFailure(Result result) =>
            result switch
            {
                { IsFailure: true } => throw new InvalidOperationException(),
                IValidationResult validationResult =>
                BadRequest(CreateProblemDetails(
                        "Validation error", StatusCodes.Status400BadRequest,
                        result.Error,
                        validationResult.Errors)),
                _ => BadRequest(
                        CreateProblemDetails(
                            "Bad Request", StatusCodes.Status400BadRequest,
                                result.Error))
            };

    private ProblemDetails CreateProblemDetails(string title, int status, Error error, Error[]? errors = null)
        => new()
        {
            Title = title,
            Type = error.Code,
            Detail = error.Message,
            Status = status,
            Extensions = { { nameof(errors), errors } }
        };
}
