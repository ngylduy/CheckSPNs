using CheckSPNs.Data.EF.Abstract;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Service.EF.Abstract;

namespace CheckSPNs.Service.EF.Implementations
{
    public class TypeOfReportService : ITypeOfReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypeOfReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> AddAsync(TypeOfReports typeOfReports)
        {
            await _unitOfWork.TypeOfReportRepository.InsertAsync(typeOfReports);
            await _unitOfWork.CommitAsync();
            return "Type of report added successfully";
        }

        public string DeleteAsync(TypeOfReports typeOfReports)
        {
            _unitOfWork.TypeOfReportRepository.Delete(typeOfReports);
            _unitOfWork.CommitAsync();
            return "Type of report deleted successfully";
        }

        public string EditAsync(TypeOfReports typeOfReports)
        {
            _unitOfWork.TypeOfReportRepository.Update(typeOfReports);
            _unitOfWork.CommitAsync();
            return "Type of report updated successfully";
        }

        public async Task<TypeOfReports> GetByIDAsync(Guid id)
        {
            return await _unitOfWork.TypeOfReportRepository.GetByIdAsync(id);
        }

        public async Task<List<TypeOfReports>> GetListAsync()
        {
            return await _unitOfWork.TypeOfReportRepository.GetAllAsync();
        }
    }
}
