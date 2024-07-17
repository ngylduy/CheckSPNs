using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Domain.ViewModel.Stats;
using CheckSPNs.Infrastructure.Features.StatsFeatures.Queries.Models;
using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.EF.Abstract;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.StatsFeatures.Queries.Handlers
{
    public class StatQueryHandler : IRequestHandler<GetPhoneNumberStatByStatusQuery, Result<PhoneNumberStatByStatus>>,
        IRequestHandler<GetReportStatByTimeQuery, Result<List<ReportStatByTime>>>,
        IRequestHandler<GetPhoneNumberTopReportQuery, Result<PagedResult<PhoneNumbers>>>,
        IRequestHandler<GetPhoneNumberTopViewQuery, Result<PagedResult<PhoneNumbers>>>,
        IRequestHandler<GetSystemStatQuery, Result<SystemStat>>
    {
        private readonly IStatService _statService;

        public StatQueryHandler(IStatService statService)
        {
            _statService = statService;
        }

        public async Task<Result<PhoneNumberStatByStatus>> Handle(GetPhoneNumberStatByStatusQuery request, CancellationToken cancellationToken)
        {
            var results = _statService.PhoneNumberStatByStatus();
            return Result.Success(results);
        }

        public async Task<Result<List<ReportStatByTime>>> Handle(GetReportStatByTimeQuery request, CancellationToken cancellationToken)
        {
            var result = await _statService.PhoneNumberStatByTime(request.From, request.To);
            return Result.Success(result);
        }

        public async Task<Result<PagedResult<PhoneNumbers>>> Handle(GetPhoneNumberTopViewQuery request, CancellationToken cancellationToken)
        {
            var result = _statService.PhoneNumberTopView();
            var pagedResult = await PagedResult<PhoneNumbers>.CreateAsync(result,
                           request.PageIndex, request.PageSize);
            return Result.Success(pagedResult);
        }

        public async Task<Result<PagedResult<PhoneNumbers>>> Handle(GetPhoneNumberTopReportQuery request, CancellationToken cancellationToken)
        {
            var result = _statService.PhoneNumberTopReport();
            var pagedResult = await PagedResult<PhoneNumbers>.CreateAsync(result,
                           request.PageIndex, request.PageSize);
            return Result.Success(pagedResult);
        }

        public async Task<Result<SystemStat>> Handle(GetSystemStatQuery request, CancellationToken cancellationToken)
        {
            var result = _statService.GetSystemStat();
            return Result.Success(result);
        }
    }
}
