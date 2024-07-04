using CheckSPNs.Data.EF.Abstract;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Service.Cache;
using CheckSPNs.Service.EF.Abstract;

namespace CheckSPNs.Service.EF.Implementations
{
    public class TypeOfReportService : ITypeOfReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributedCacheService _distributedCacheService;

        public TypeOfReportService(IUnitOfWork unitOfWork, IDistributedCacheService distributedCacheService)
        {
            _unitOfWork = unitOfWork;
            _distributedCacheService = distributedCacheService;
        }

        public async Task AddAsync(TypeOfReports typeOfReports)
        {
            await _unitOfWork.TypeOfReportRepository.InsertAsync(typeOfReports);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(TypeOfReports typeOfReports)
        {
            _unitOfWork.TypeOfReportRepository.Delete(typeOfReports);
            await _unitOfWork.CommitAsync();
        }

        public async Task EditAsync(TypeOfReports typeOfReports)
        {
            _unitOfWork.TypeOfReportRepository.Update(typeOfReports);
            await _unitOfWork.CommitAsync();
        }

        public async Task<TypeOfReports> GetByIDAsync(Guid id)
        {
            var resultCache = await _distributedCacheService.Get<TypeOfReports>($"cache_typeofreports_{id}");

            if (resultCache != null)
            {
                return resultCache;
            }

            var typeOfReport = await _unitOfWork.TypeOfReportRepository.GetByIdAsync(id);

            await _distributedCacheService.Set($"cache_typeofreports_{id}", typeOfReport);

            return typeOfReport;
        }

        public async Task<List<TypeOfReports>> GetListAsync()
        {
            return await _unitOfWork.TypeOfReportRepository.GetAllAsync();
        }

        public async Task<bool> IsTypeOfReportExit(string typeOfReport)
        {
            var typeOfReports = await _unitOfWork.TypeOfReportRepository.GetSingleByConditionAsync(x => x.TypeOfReport.Equals(typeOfReport));
            if (typeOfReports == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> IsTypeOfReportExitExcludeSelf(string typeOfReport, Guid id)
        {
            var typeOfReports = await _unitOfWork.TypeOfReportRepository.GetSingleByConditionAsync(x => x.TypeOfReport.Equals(typeOfReport) & !x.Id.Equals(id));
            if (typeOfReports == null)
            {
                return false;
            }
            return true;
        }
    }
}
