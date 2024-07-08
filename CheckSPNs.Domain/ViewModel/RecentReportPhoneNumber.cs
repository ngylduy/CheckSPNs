using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;

namespace CheckSPNs.Domain.ViewModel
{
    public class RecentReportPhoneNumber
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public DateTime DateAdded { get; set; }
        public int TimesReported { get; set; }

        public Reports Reports { get; set; }
    }
}
