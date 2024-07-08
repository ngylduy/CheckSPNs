using AutoMapper;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Domain.ViewModel;
using CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Models;
using CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Results;
using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.EF.Abstract;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Handlers;

public class PhoneNumberQueryHandler : IRequestHandler<GetPhoneNumberListQuery, Result<List<GetListPhoneNumberResponse>>>,
    IRequestHandler<GetPhoneNumberPrefixQuery, Result<List<GetListPrefixResponse>>>,
    IRequestHandler<GetRecentReportPhoneNumberQuery, Result<PagedResult<RecentReportPhoneNumber>>>,
    IRequestHandler<GetPhoneNumberQuery, Result<PhoneNumbers>>
{

    private readonly IPhoneNumberService _phoneNumberService;
    private readonly IMapper _mapper;

    public PhoneNumberQueryHandler(IPhoneNumberService phoneNumberService, IMapper mapper)
    {
        _phoneNumberService = phoneNumberService;
        _mapper = mapper;
    }
    public async Task<Result<List<GetListPhoneNumberResponse>>> Handle(GetPhoneNumberListQuery request, CancellationToken cancellationToken)
    {
        var listPhoneNumber = await _phoneNumberService.GetListAsync();
        var listPhoneNumberMapper = _mapper.Map<List<GetListPhoneNumberResponse>>(listPhoneNumber);
        return Result.Success(listPhoneNumberMapper);
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
}
