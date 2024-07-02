using System.ComponentModel.DataAnnotations.Schema;

namespace CheckSPNs.Domain.Models.EF.CheckPhoneNumber
{
    public class TypeOfReports : BaseEntity
    {
        public string TypeOfReport { get; set; } = null!;
        [InverseProperty("TypeOfReports")]
        public virtual ICollection<PhoneNumbersTypeOfReports> PhoneNumbersTypeOfReports { get; set; }
    }
}
