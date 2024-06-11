using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSPNs.Domain.Models
{
    public class Reports : BaseEntity
    {
        public Guid PhoneNumberID { get; set; }
        public Guid UserID { get; set; }
        public DateTime ReportDate { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }

        public PhoneNumbers? PhoneNumber { get; set; }
        public AppUsers? AppUsers { get; set; }
    }
}
