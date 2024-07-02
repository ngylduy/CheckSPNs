using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;

namespace CheckSPNs.Infrastructure.Features.ReportFeatures.Queries.Results
{
    public class GetListReportResponse
    {
        public Guid Id { get; set; }
        public DateTime ReportDate { get; set; }
        public string Comment { get; set; }
        public PhoneNumbers PhoneNumber { get; set; }
    }
}
