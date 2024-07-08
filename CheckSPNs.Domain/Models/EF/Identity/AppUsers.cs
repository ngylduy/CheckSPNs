using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entities.Identity;

namespace CheckSPNs.Domain.Models.EF.Identity
{
    public class AppUsers : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string? PictureUser { get; set; }
        public string? Sex { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}
