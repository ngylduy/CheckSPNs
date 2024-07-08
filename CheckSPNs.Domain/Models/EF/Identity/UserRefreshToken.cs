using CheckSPNs.Domain.Models.EF;
using CheckSPNs.Domain.Models.EF.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities.Identity
{
    public class UserRefreshToken : BaseEntity
    {
        public Guid UserId { get; set; }

        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime ExpiryDate { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual AppUsers? AppUsers { get; set; }
    }
}
