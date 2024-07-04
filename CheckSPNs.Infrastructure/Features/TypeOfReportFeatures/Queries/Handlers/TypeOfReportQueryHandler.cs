using AutoMapper;
using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Queries.Models;
using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Queries.Results;
using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.EF.Abstract;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Queries.Handlers
{
    public class TypeOfReportQueryHandler : IRequestHandler<GetTypeOfReportListQuery, Result<List<GetTypeOfReportListResponse>>>
    {

        private readonly ITypeOfReportService _typeOfReportService;
        private readonly IMapper _mapper;

        public TypeOfReportQueryHandler(ITypeOfReportService typeOfReportService, IMapper mapper)
        {
            _typeOfReportService = typeOfReportService;
            _mapper = mapper;
        }

        public async Task<Result<List<GetTypeOfReportListResponse>>> Handle(GetTypeOfReportListQuery request, CancellationToken cancellationToken)
        {
            var typeOfReportList = await _typeOfReportService.GetListAsync();
            var typeOfReportListMapper = _mapper.Map<List<GetTypeOfReportListResponse>>(typeOfReportList);
            return Result.Success(typeOfReportListMapper);
        }
    }
}
