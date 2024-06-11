using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSPNs.Domain.Models
{
    public class PhoneNumbers : BaseEntity
    {
        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; } = null!;
        public int CategoryID { get; set; }
        public DateTime DateAdded { get; set; }
        public int TimesReported { get; set; }

        public TypeOfReports? TypeOfReports { get; set; }
        public ICollection<Reports>? Reports { get; set; }
        public ICollection<ViewLogs>? ViewLogs { get; set; }
    }
}
