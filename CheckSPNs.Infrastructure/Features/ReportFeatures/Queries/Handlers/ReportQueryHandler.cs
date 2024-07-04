using AutoMapper;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Infrastructure.Features.ReportFeatures.Queries.Models;
using CheckSPNs.Infrastructure.Features.ReportFeatures.Queries.Results;
using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.EF.Abstract;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.ReportFeatures.Queries.Handlers;

public class ReportQueryHandler : IRequestHandler<GetListReportByPhoneNumberQuery, Result<List<GetListReportResponse>>>,
                    IRequestHandler<GetListReportQuery, Result<PagedResult<GetListReportResponse>>>
{
    private readonly IReportService _reportService;
    private readonly IMapper _mapper;

    public ReportQueryHandler(IReportService reportService, IMapper mapper)
    {
        _reportService = reportService;
        _mapper = mapper;
    }

    public async Task<Result<List<GetListReportResponse>>> Handle(GetListReportByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var listReport = await _reportService.GetListByPhoneNumberId(request.PhoneNumberId);
        var listReportMapper = _mapper.Map<List<GetListReportResponse>>(listReport);
        return Result.Success(listReportMapper);
    }

    public async Task<Result<PagedResult<GetListReportResponse>>> Handle(GetListReportQuery request, CancellationToken cancellationToken)
    {
        var listReport = _reportService.GetReportsQuerable();
        var pagedReport = await PagedResult<Reports>.CreateAsync(listReport, request.PageIndex, request.PageSize);
        var listReportMapper = _mapper.Map<PagedResult<GetListReportResponse>>(pagedReport);
        return Result.Success(listReportMapper);
    }
}
