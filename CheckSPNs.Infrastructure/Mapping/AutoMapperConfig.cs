using AutoMapper;
using CheckSPNs.Domain.DTO;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Domain.Models.MongoDb.CheckExamScore;
using CheckSPNs.Domain.ViewModel;
using CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Queries.Results;
using CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Results;
using CheckSPNs.Infrastructure.Features.ReportFeatures.Commands.Models;
using CheckSPNs.Infrastructure.Features.ReportFeatures.Queries.Results;
using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Commands.Models;
using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Queries.Results;
using CheckSPNs.Infrastructure.Shared;

namespace CheckSPNs.Infrastructure.Mapping;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<AddTypeOfReportCommand, TypeOfReports>();
        CreateMap<TypeOfReports, GetTypeOfReportListResponse>();
        //CreateMap<AddPhoneNumberCommand, PhoneNumbers>();
        CreateMap<PhoneNumbers, GetListPhoneNumberResponse>();
        CreateMap<Reports, GetListReportResponse>();

        CreateMap<EditReportCommand, Reports>();

        CreateMap<PagedResult<Reports>, PagedResult<GetListReportResponse>>();

        CreateMap<ExamScoreDTO, ExamScore>();
        CreateMap<ExamScoreDTO, GetSingleExamScoreResponse>();

        CreateMap<AggregatePrefixPhoneNumber, GetListPrefixResponse>();

        CreateMap<EditTypeOfReportCommand, TypeOfReports>();
    }
}
