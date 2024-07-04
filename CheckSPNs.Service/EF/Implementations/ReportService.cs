using CheckSPNs.Data.EF.Abstract;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Service.Cache;
using CheckSPNs.Service.EF.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CheckSPNs.Service.EF.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributedCacheService _distributedCacheService;

        public ReportService(IUnitOfWork unitOfWork, IDistributedCacheService distributedCacheService)
        {
            _unitOfWork = unitOfWork;
            _distributedCacheService = distributedCacheService;
        }

        public async Task AddReport(string report, string phoneNumber)
        {
            var phoneNumbers = await _unitOfWork.PhoneNumberRepository.GetInfoByPhoneNumber(phoneNumber);

            if (phoneNumbers == null)
            {
                throw new Exception("Phone Number not found");
            }

            var reportEntity = new Reports
            {
                Comment = report,
                ReportDate = DateTime.Now,
                PhoneNumberID = phoneNumbers.Id
            };

            await _unitOfWork.ReportRepository.InsertAsync(reportEntity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Reports reports)
        {
            _unitOfWork.ReportRepository.Delete(reports);
            await _unitOfWork.CommitAsync();
        }

        public async Task EditAsync(Reports reports)
        {
            _unitOfWork.ReportRepository.Update(reports);
            await _unitOfWork.CommitAsync();
        }

        public Task<List<Reports>> GetListByPhoneNumberId(Guid phoneNumberId)
        {
            return _unitOfWork.ReportRepository.GetListByPhoneNumber(phoneNumberId);
        }

        public IQueryable<Reports> GetReportsQuerable()
        {
            return _unitOfWork.ReportRepository.GetTableNoTracking().Include(x => x.PhoneNumber).OrderByDescending(x => x.ReportDate).AsQueryable();
        }

        public async Task<Reports> GetReportByIdAsync(Guid id)
        {
            var resultCache = await _distributedCacheService.Get<Reports>($"cache_report_{id}");

            if (resultCache != null)
            {
                return resultCache;
            }

            var report = await _unitOfWork.ReportRepository.GetByIdAsync(id);

            await _distributedCacheService.Set($"cache_report_{id}", report);

            return report;
        }
    }
}
