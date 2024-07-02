using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;

namespace CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Results
{
    public class GetSinglePhoneNumberResponse
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateAdded { get; set; }
        public int TimesReported { get; set; }
        public int PositiveReportsCount { get; set; }
        public int NegativeReportsCount { get; set; }
        public string OverallReportStatus { get; set; }
        ICollection<Reports> Reports { get; set; }

    }
}
