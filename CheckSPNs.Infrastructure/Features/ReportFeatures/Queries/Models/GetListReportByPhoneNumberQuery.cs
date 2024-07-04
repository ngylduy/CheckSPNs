using CheckSPNs.Infrastructure.Features.ReportFeatures.Queries.Results;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.ReportFeatures.Queries.Models
{
    public class GetListReportByPhoneNumberQuery : IRequest<Result<List<GetListReportResponse>>>
    {
        public GetListReportByPhoneNumberQuery(Guid phoneNumberId)
        {
            PhoneNumberId = phoneNumberId;
        }

        public Guid PhoneNumberId { get; set; }
    }
}
