using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSPNs.Domain.Models
{
    public class ViewLogs : BaseEntity
    {
        public Guid PhoneNumberId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ViewDate { get; set; }
        public PhoneNumbers? PhoneNumber { get; set; }
        //public AppUsers User { get; set; }
    }
}
