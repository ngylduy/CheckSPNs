using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSPNs.Domain.Models
{
    public class AppUsers : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string PictureUser { get; set; } = null!;
        public string Sex { get; set; } = null!;
        public DateTime DateCreated { get; set; }

        public ICollection<Reports>? Reports { get; set; }
        public ICollection<ViewLogs>? ViewLogs { get; set; }
    }
}
