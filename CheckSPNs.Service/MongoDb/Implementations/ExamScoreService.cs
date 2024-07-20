using CheckSPNs.Data.MongoDb.Abstract;
using CheckSPNs.Domain.DTO;
using CheckSPNs.Domain.Models.MongoDb.CheckExamScore;
using CheckSPNs.Service.MongoDb.Abstract;

namespace CheckSPNs.Service.MongoDb.Implementations
{
    public class ExamScoreService : IExamScoreService
    {
        private readonly IMongoRepository<ExamScore2024> _examScoreRepository;
        private readonly IMongoRepository<ProvinceCity> _provinceCityRepository;

        public ExamScoreService(IMongoRepository<ExamScore2024> examScoreRepository, IMongoRepository<ProvinceCity> provinceCityRepository)
        {
            _examScoreRepository = examScoreRepository;
            _provinceCityRepository = provinceCityRepository;
        }

        public IQueryable<ExamScore2024> GetExamScore() => _examScoreRepository.GetAll();


        public async Task<ExamScoreDTO> GetExamScoreByIdAsync(string id)
        {
            var score = await _examScoreRepository.GetByIdAsync(id);
            if (score == null)
            {
                return null;
            }
            var provinceCode = score.StudentId.Substring(0, 2);
            var provinceCityCodes = await _provinceCityRepository.GetByIdAsync(provinceCode);
            return new ExamScoreDTO
            {
                StudentId = score.StudentId,
                Toan = score.Toan,
                NguVan = score.NguVan,
                NgoaiNgu = score.NgoaiNgu,
                VatLi = score.VatLi,
                HoaHoc = score.HoaHoc,
                SinhHoc = score.SinhHoc,
                LichSu = score.LichSu,
                DiaLi = score.DiaLi,
                Gdcd = score.Gdcd,
                MaNgoaiNgu = score.MaNgoaiNgu,
                ProvinceCity = provinceCityCodes != null ? provinceCityCodes.ProvinceCityName : "Unknown"
            };
        }

        public async Task<string> ImportCsv(List<ExamScore2024> examScore)
        {
            await _examScoreRepository.InsertAsync(examScore);
            return "Success";
        }

        public async Task<string> ImportProvinceCity(List<ProvinceCity> provinceCities)
        {
            await _provinceCityRepository.InsertAsync(provinceCities);
            return "Success";
        }
    }
}
