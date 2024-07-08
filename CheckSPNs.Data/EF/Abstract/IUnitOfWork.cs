using CheckSPNs.Data.EF.Implementations;
using CheckSPNs.Domain.Models.MongoDb.CheckExamScore;
using SchoolProject.Data.Entities.Identity;

namespace CheckSPNs.Data.EF.Abstract
{
    public interface IUnitOfWork
    {
        Repository<ExamScore> RepositoryExamScore { get; }
        Repository<ProvinceCity> RepositoryProvinceCity { get; }
        Repository<UserRefreshToken> RepositoryUserRefreshToken { get; }

        PhoneNumberTypeOfReportRepository PhoneNumberTypeOfReportRepository { get; }
        TypeOfReportRepository TypeOfReportRepository { get; }
        PhoneNumberRepository PhoneNumberRepository { get; }
        ReportRepository ReportRepository { get; }


        Task CommitAsync();
    }
}
