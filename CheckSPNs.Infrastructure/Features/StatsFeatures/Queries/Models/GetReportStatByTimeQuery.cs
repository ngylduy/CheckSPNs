using CheckSPNs.Domain.ViewModel.Stats;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.StatsFeatures.Queries.Models
{
    public class GetReportStatByTimeQuery : IRequest<Result<List<ReportStatByTime>>>
    {
        public GetReportStatByTimeQuery(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
