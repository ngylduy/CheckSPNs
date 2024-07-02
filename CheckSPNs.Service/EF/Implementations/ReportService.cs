using CheckSPNs.Data.EF.Abstract;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Service.EF.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CheckSPNs.Service.EF.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public Task<List<Reports>> GetListByPhoneNumberId(Guid phoneNumberId)
        {
            return _unitOfWork.ReportRepository.GetListByPhoneNumber(phoneNumberId);
        }

        public IQueryable<Reports> GetReportsQuerable()
        {
            return _unitOfWork.ReportRepository.GetTableNoTracking().Include(x => x.PhoneNumber).OrderBy(x => x.ReportDate).AsQueryable();
        }
    }
}
