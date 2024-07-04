using AutoMapper;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Commands.Models;
using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.EF.Abstract;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Commands.Handlers;

public class TypeOfReportCommandHandler : IRequestHandler<AddTypeOfReportCommand, Result>,
    IRequestHandler<EditTypeOfReportCommand, Result>,
    IRequestHandler<DeleteTypeOfReportCommand, Result>
{
    private readonly ITypeOfReportService _typeOfReportService;
    private readonly IMapper _mapper;

    public TypeOfReportCommandHandler(ITypeOfReportService typeOfReportService, IMapper mapper)
    {
        _typeOfReportService = typeOfReportService;
        _mapper = mapper;
    }

    public async Task<Result> Handle(AddTypeOfReportCommand request, CancellationToken cancellationToken)
    {
        var typeOfReport = _mapper.Map<TypeOfReports>(request);
        await _typeOfReportService.AddAsync(typeOfReport);
        return Result.Success();
    }

    public async Task<Result> Handle(DeleteTypeOfReportCommand request, CancellationToken cancellationToken)
    {
        var typeOfReport = _typeOfReportService.GetByIDAsync(request.Id).Result;
        if (typeOfReport == null)
        {
            return Result.Failure(Error.None);
        }
        await _typeOfReportService.DeleteAsync(typeOfReport);

        return Result.Success();
    }

    public async Task<Result> Handle(EditTypeOfReportCommand request, CancellationToken cancellationToken)
    {
        var typeOfReport = _typeOfReportService.GetByIDAsync(request.Id).Result;
        if (typeOfReport == null)
        {
            return Result.Failure(Error.NullValue);
        }
        var typeOfReportModel = _mapper.Map(request, typeOfReport);
        await _typeOfReportService.EditAsync(typeOfReportModel);

        return Result.Success();
    }
}
