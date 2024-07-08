using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.IdentityFeatures.ApplicationUser.Commands.Models
{
    public class AddUserCommand : IRequest<Result>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Dob { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
