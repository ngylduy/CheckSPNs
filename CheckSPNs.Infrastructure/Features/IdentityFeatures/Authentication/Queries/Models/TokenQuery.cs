using CheckSPNs.Domain;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.IdentityFeatures.Authentication.Queries.Models
{
    public class TokenQuery : IRequest<Result<JwtModel>>
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
