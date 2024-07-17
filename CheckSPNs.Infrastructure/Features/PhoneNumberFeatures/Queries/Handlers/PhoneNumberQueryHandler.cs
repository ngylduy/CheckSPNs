using AutoMapper;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Domain.ViewModel;
using CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Models;
using CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Results;
using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.EF.Abstract;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Handlers;

public class PhoneNumberQueryHandler : IRequestHandler<GetPhoneNumberListQuery, Result<PagedResult<PhoneNumbers>>>,
    IRequestHandler<GetPhoneNumberPrefixQuery, Result<List<GetListPrefixResponse>>>,
    IRequestHandler<GetRecentReportPhoneNumberQuery, Result<PagedResult<RecentReportPhoneNumber>>>,
    IRequestHandler<GetPhoneNumberQuery, Result<PhoneNumbers>>,
    IRequestHandler<GetRecentReportPhoneNumberByTypeQuery, Result<PagedResult<RecentReportPhoneNumberByType>>>
{

    private readonly IPhoneNumberService _phoneNumberService;
    private readonly IMapper _mapper;

    public PhoneNumberQueryHandler(IPhoneNumberService phoneNumberService, IMapper mapper)
    {
        _phoneNumberService = phoneNumberService;
        _mapper = mapper;
    }

    public async Task<Result<List<GetListPrefixResponse>>> Handle(GetPhoneNumberPrefixQuery request, CancellationToken cancellationToken)
    {
        var listPrefix = await _phoneNumberService.AggregateByPrefix();
        var listPrefixMapper = _mapper.Map<List<GetListPrefixResponse>>(listPrefix);
        return Result.Success(listPrefixMapper);
    }

    public async Task<Result<PagedResult<RecentReportPhoneNumber>>> Handle(GetRecentReportPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var listRecentReportPhoneNumber = _phoneNumberService.GetRecentReportPhoneNumbers();
        var pagedResult = await PagedResult<RecentReportPhoneNumber>.CreateAsync(listRecentReportPhoneNumber,
            request.PageIndex, request.PageSize);
        return Result.Success(pagedResult);
    }

    public async Task<Result<PhoneNumbers>> Handle(GetPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var phoneNumber = await _phoneNumberService.GetInfoByPhoneNumber(request.PhoneNumber);
        return Result.Success(phoneNumber);
    }

    public async Task<Result<PagedResult<RecentReportPhoneNumberByType>>> Handle(GetRecentReportPhoneNumberByTypeQuery request, CancellationToken cancellationToken)
    {
        var listRecentReportPhoneNumber = _phoneNumberService.GetRecentReportPhoneNumbersByType(request.TypeOfReport);
        var pagedResult = await PagedResult<RecentReportPhoneNumberByType>.CreateAsync(listRecentReportPhoneNumber,
                       request.PageIndex, request.PageSize);
        return Result.Success(pagedResult);
    }

    public async Task<Result<PagedResult<PhoneNumbers>>> Handle(GetPhoneNumberListQuery request, CancellationToken cancellationToken)
    {
        var listPhoneNumber = _phoneNumberService.GetAllPhoneNumber();
        var pagedResult = await PagedResult<PhoneNumbers>.CreateAsync(listPhoneNumber,
                       request.PageIndex, request.PageSize);
        return Result.Success(pagedResult);
    }
}
