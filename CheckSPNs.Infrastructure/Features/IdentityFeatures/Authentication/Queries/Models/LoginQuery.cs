using CheckSPNs.Domain;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.IdentityFeatures.Authentication.Queries.Models
{
    public class LoginQuery : IRequest<Result<JwtModel>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
