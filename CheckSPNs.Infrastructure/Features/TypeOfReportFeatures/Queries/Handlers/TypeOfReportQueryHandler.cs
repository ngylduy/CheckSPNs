using AutoMapper;
using CheckSPNs.Infrastructure.Bases;
using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Queries.Models;
using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Queries.Results;
using CheckSPNs.Service.EF.Abstract;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Queries.Handlers
{
    public class TypeOfReportQueryHandler : ResponseHandler,
        IRequestHandler<GetTypeOfReportListQuery, Response<List<GetTypeOfReportListResponse>>>
    {

        private readonly ITypeOfReportService _typeOfReportService;
        private readonly IMapper _mapper;

        public TypeOfReportQueryHandler(ITypeOfReportService typeOfReportService, IMapper mapper)
        {
            _typeOfReportService = typeOfReportService;
            _mapper = mapper;
        }

        public async Task<Response<List<GetTypeOfReportListResponse>>> Handle(GetTypeOfReportListQuery request, CancellationToken cancellationToken)
        {
            var typeOfReportList = await _typeOfReportService.GetListAsync();
            var typeOfReportListMapper = _mapper.Map<List<GetTypeOfReportListResponse>>(typeOfReportList);
            var result = Success(typeOfReportListMapper);
            result.Meta = new { Count = typeOfReportListMapper.Count() };
            return result;
        }
    }
}
