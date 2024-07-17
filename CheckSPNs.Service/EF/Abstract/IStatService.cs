using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Domain.ViewModel.Stats;

namespace CheckSPNs.Service.EF.Abstract;

public interface IStatService
{
    PhoneNumberStatByStatus PhoneNumberStatByStatus();
    Task<List<ReportStatByTime>> PhoneNumberStatByTime(DateTime from, DateTime to);
    IQueryable<PhoneNumbers> PhoneNumberTopView();
    IQueryable<PhoneNumbers> PhoneNumberTopReport();
    SystemStat GetSystemStat();
}
