using AutoMapper;
using CheckSPNs.Infrastructure.Features.ReportFeatures.Commands.Models;
using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.EF.Abstract;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.ReportFeatures.Commands.Handler
{
    public class ReportCommandHandler : IRequestHandler<AddReportCommand, Result>,
        IRequestHandler<EditReportCommand, Result>,
        IRequestHandler<DeleteReportCommand, Result>
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;

        public ReportCommandHandler(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        public async Task<Result> Handle(AddReportCommand request, CancellationToken cancellationToken)
        {
            await _reportService.AddReport(request.Comment, request.PhoneNumber);
            return Result.Success();
        }

        public async Task<Result> Handle(DeleteReportCommand request, CancellationToken cancellationToken)
        {
            var report = await _reportService.GetReportByIdAsync(request.Id);
            if (report == null)
            {
                return Result.Failure(Error.NullValue);
            }
            await _reportService.DeleteAsync(report);

            return Result.Success();
        }

        public async Task<Result> Handle(EditReportCommand request, CancellationToken cancellationToken)
        {
            var report = _reportService.GetReportByIdAsync(request.Id).Result;
            if (report == null)
            {
                return Result.Failure(Error.NullValue);
            }
            var reportModel = _mapper.Map(request, report);
            await _reportService.EditAsync(report);

            return Result.Success();
        }
    }
}
