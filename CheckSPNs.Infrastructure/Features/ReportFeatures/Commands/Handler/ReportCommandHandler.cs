using CheckSPNs.Infrastructure.Features.ReportFeatures.Commands.Models;
using CheckSPNs.Service.Application.Shared;
using CheckSPNs.Service.EF.Abstract;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.ReportFeatures.Commands.Handler
{
    public class ReportCommandHandler : IRequestHandler<AddReportCommand, Result>
    {
        private readonly IReportService _reportService;

        public ReportCommandHandler(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task<Result> Handle(AddReportCommand request, CancellationToken cancellationToken)
        {
            await _reportService.AddReport(request.Comment, request.PhoneNumber);
            return Result.Success();
        }
    }
}
