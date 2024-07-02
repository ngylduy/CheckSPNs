using Microsoft.AspNetCore.Identity;

namespace CheckSPNs.Domain.Models.EF.Identity
{
    public class AppUsers : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string PictureUser { get; set; } = null!;
        public string Sex { get; set; } = null!;
        public DateTime DateCreated { get; set; }
    }
}
