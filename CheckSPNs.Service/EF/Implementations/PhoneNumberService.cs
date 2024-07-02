using CheckSPNs.Data.EF.Abstract;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Domain.Models.EF.Enums;
using CheckSPNs.Domain.ViewModel;
using CheckSPNs.Service.Cache;
using CheckSPNs.Service.EF.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CheckSPNs.Service.EF.Implementations
{
    public class PhoneNumberService : IPhoneNumberService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributedCacheService _distributedCacheService;

        public PhoneNumberService(IUnitOfWork unitOfWork, IDistributedCacheService distributedCacheService)
        {
            _unitOfWork = unitOfWork;
            _distributedCacheService = distributedCacheService;
        }

        public async Task<PhoneNumbers> AddAsync(string phoneNumber)
        {
            var phoneNumbers = new PhoneNumbers
            {
                PhoneNumber = phoneNumber
            };

            phoneNumbers.DateAdded = DateTime.Now;

            await _unitOfWork.PhoneNumberRepository.InsertAsync(phoneNumbers);
            await _unitOfWork.CommitAsync();

            return phoneNumbers;
        }

        public async Task UpdateOverallReport(PhoneNumberOverallReportEnum phoneNumberOverallReport, string phoneNumber)
        {
            var phoneNumbers = await _unitOfWork.PhoneNumberRepository.GetInfoByPhoneNumber(phoneNumber);
            if (phoneNumbers != null)
            {
                switch (phoneNumberOverallReport)
                {
                    case PhoneNumberOverallReportEnum.Negative:
                        phoneNumbers.NegativeReportsCount++;
                        break;
                    case PhoneNumberOverallReportEnum.Positive:
                        phoneNumbers.PositiveReportsCount++;
                        break;
                }
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task AddTypeReport(string phoneNumber, Guid typeOfReport)
        {
            var phoneNumbers = await _unitOfWork.PhoneNumberRepository.GetInfoByPhoneNumber(phoneNumber);

            if (phoneNumbers == null)
            {
                throw new Exception("Phone Number not found");
            }

            var typeOfReportEntity = _unitOfWork.PhoneNumberTypeOfReportRepository.GetByPhoneNumberAndTypeOfReportAsync(phoneNumbers.Id, typeOfReport);

            if (!typeOfReportEntity)
            {
                await _unitOfWork.PhoneNumberTypeOfReportRepository.InsertAsync(new PhoneNumbersTypeOfReports
                {
                    PhoneNumbersId = phoneNumbers.Id,
                    TypeOfReportsId = typeOfReport
                });
            }

            phoneNumbers.TimesReported++;

            _unitOfWork.PhoneNumberRepository.Update(phoneNumbers);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<PhoneNumbers>> GetListAsync()
        {
            var resultCache = await _distributedCacheService.Get<List<PhoneNumbers>>($"cache_list_phonenumber");

            if (resultCache != null)
            {
                return resultCache;
            }

            var listPhoneNumbers = await _unitOfWork.PhoneNumberRepository.GetAllAsync();

            await _distributedCacheService.Set($"cache_list_phonenumber", listPhoneNumbers);

            return listPhoneNumbers;
        }

        public async Task<PhoneNumbers> GetPhoneNumberByIdAsync(Guid id)
        {
            var resultCache = await _distributedCacheService.Get<PhoneNumbers>($"cache_phonenumber_{id}");

            if (resultCache != null)
            {
                return resultCache;
            }

            var phoneNumber = await _unitOfWork.PhoneNumberRepository.GetByIdAsync(id);

            await _distributedCacheService.Set($"cache_phonenumber_{id}", phoneNumber);

            return phoneNumber;
        }

        public async Task<PhoneNumbers> GetInfoByPhoneNumber(string phoneNumber)
        {
            var resultCache = await _distributedCacheService.Get<PhoneNumbers>($"cache_phonenumber_info_{phoneNumber}");

            if (resultCache != null)
            {
                return resultCache;
            }

            var phoneNumbers = await _unitOfWork.PhoneNumberRepository.GetInfoByPhoneNumber(phoneNumber);

            await _distributedCacheService.Set($"cache_phonenumber_info_{phoneNumber}", phoneNumber);

            return phoneNumbers;
        }

        public async Task<List<AggregatePrefixPhoneNumber>> AggregateByPrefix()
        {
            return await _unitOfWork.PhoneNumberRepository.GetTableNoTracking()
                .GroupBy(p => p.PhoneNumber.Substring(0, 4))
                .Select(p => new AggregatePrefixPhoneNumber
                {
                    Prefix = p.Key,
                    Count = p.Count()
                }).ToListAsync();
        }

    }
}
