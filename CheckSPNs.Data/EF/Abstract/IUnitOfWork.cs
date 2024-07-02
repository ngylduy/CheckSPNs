using CheckSPNs.Data.EF.Implementations;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Domain.Models.MongoDb.CheckExamScore;

namespace CheckSPNs.Data.EF.Abstract
{
    public interface IUnitOfWork
    {
        Repository<UserTokens> RepositoryUserToken { get; }
        Repository<ExamScore> RepositoryExamScore { get; }
        Repository<ProvinceCity> RepositoryProvinceCity { get; }

        PhoneNumberTypeOfReportRepository PhoneNumberTypeOfReportRepository { get; }
        TypeOfReportRepository TypeOfReportRepository { get; }
        PhoneNumberRepository PhoneNumberRepository { get; }
        ReportRepository ReportRepository { get; }


        Task CommitAsync();
    }
}
