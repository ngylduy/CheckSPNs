using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CheckSPNs.Domain.Models.EF.CheckPhoneNumber
{
    public class PhoneNumbers : BaseEntity
    {
        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; } = null!;
        public DateTime DateAdded { get; set; }
        public long TimesReported { get; set; }
        public long Views { get; set; }

        public long PositiveReportsCount { get; set; }
        public long NegativeReportsCount { get; set; }

        [NotMapped]
        public string OverallReportStatus
        {
            get
            {
                if (PositiveReportsCount > NegativeReportsCount)
                {
                    return "Positive";
                }
                else if (NegativeReportsCount > PositiveReportsCount)
                {
                    return "Negative";
                }
                else
                {
                    return "Neutral";
                }
            }
        }

        [InverseProperty("PhoneNumber")]
        [JsonIgnore]
        public virtual ICollection<Reports> Reports { get; set; }
        [InverseProperty("PhoneNumbers")]
        [JsonIgnore]
        public virtual ICollection<PhoneNumbersTypeOfReports> PhoneNumbersTypeOfReports { get; set; }
    }
}
