using AutoMapper;
using CheckSPNs.Domain.DTO;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Domain.Models.EF.Identity;
using CheckSPNs.Domain.Models.MongoDb.CheckExamScore;
using CheckSPNs.Domain.ViewModel;
using CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Queries.Results;
using CheckSPNs.Infrastructure.Features.IdentityFeatures.ApplicationUser.Commands.Models;
using CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Commands.Models;
using CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Results;
using CheckSPNs.Infrastructure.Features.ReportFeatures.Commands.Models;
using CheckSPNs.Infrastructure.Features.ReportFeatures.Queries.Results;
using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Commands.Models;
using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Queries.Results;
using CheckSPNs.Infrastructure.Shared;
using SchoolProject.Core.Features.Authorization.Quaries.Results;

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
        CreateMap<ExamScoreDTO, ExamScore2024>();
        CreateMap<ExamScoreDTO, GetSingleExamScoreResponse>();

        CreateMap<AggregatePrefixPhoneNumber, GetListPrefixResponse>();

        CreateMap<EditTypeOfReportCommand, TypeOfReports>();
        CreateMap<EditPhoneNumberCommand, PhoneNumbers>();

        CreateMap<AddUserCommand, AppUsers>();

        CreateMap<AppRoles, GetRolesListResult>();
        CreateMap<AppRoles, GetRoleByIdResult>();
    }
}
