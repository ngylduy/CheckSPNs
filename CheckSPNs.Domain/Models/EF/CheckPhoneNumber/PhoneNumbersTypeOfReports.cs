using System.ComponentModel.DataAnnotations.Schema;

namespace CheckSPNs.Domain.Models.EF.CheckPhoneNumber
{
    public class PhoneNumbersTypeOfReports
    {
        public Guid PhoneNumbersId { get; set; }
        public Guid TypeOfReportsId { get; set; }
        [ForeignKey("PhoneNumbersId")]
        [InverseProperty("PhoneNumbersTypeOfReports")]
        public PhoneNumbers PhoneNumbers { get; set; } = null!;
        [ForeignKey("TypeOfReportsId")]
        [InverseProperty("PhoneNumbersTypeOfReports")]
        public TypeOfReports TypeOfReports { get; set; } = null!;
    }
}
