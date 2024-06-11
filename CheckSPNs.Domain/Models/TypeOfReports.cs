using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSPNs.Domain.Models
{
    public class TypeOfReports : BaseEntity
    {
        public string TypeOfReport { get; set; } = null!;

        public ICollection<PhoneNumbers>? PhoneNumbers { get; set; }
    }
}
