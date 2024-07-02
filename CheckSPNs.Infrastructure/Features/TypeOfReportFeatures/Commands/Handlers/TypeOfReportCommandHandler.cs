using AutoMapper;
using CheckSPNs.Infrastructure.Bases;
using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Commands.Models;
using CheckSPNs.Service.EF.Abstract;
using MediatR;
using Model = CheckSPNs.Domain.Models.EF.CheckPhoneNumber;

namespace CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Commands.Handlers;

public class TypeOfReportCommandHandler : ResponseHandler,
    IRequestHandler<AddTypeOfReportCommand, Response<string>>
{
    private readonly ITypeOfReportService _typeOfReportService;
    private readonly IMapper _mapper;

    public TypeOfReportCommandHandler(ITypeOfReportService typeOfReportService, IMapper mapper)
    {
        _typeOfReportService = typeOfReportService;
        _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddTypeOfReportCommand request, CancellationToken cancellationToken)
    {
        var typeOfReport = _mapper.Map<Model.TypeOfReports>(request);
        var result = await _typeOfReportService.AddAsync(typeOfReport);
        if (result == "Type of report added successfully")
        {
            return Created(result);
        }
        else return BadRequest<string>(result);
    }
}
