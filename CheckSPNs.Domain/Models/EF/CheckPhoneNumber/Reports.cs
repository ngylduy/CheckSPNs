using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CheckSPNs.Domain.Models.EF.CheckPhoneNumber
{
    public class Reports : BaseEntity
    {
        public Guid PhoneNumberID { get; set; }
        public DateTime ReportDate { get; set; }
        public string? Comment { get; set; }
        [InverseProperty("Reports")]
        [JsonIgnore]
        public PhoneNumbers? PhoneNumber { get; set; }
    }
}
