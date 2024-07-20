using AutoMapper;
using CheckSPNs.Domain.DTO;
using CheckSPNs.Domain.Models.MongoDb.CheckExamScore;
using CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Commands.Models;
using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.CSV;
using CheckSPNs.Service.MongoDb.Abstract;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Commands.Handlers
{
    public class ExamScoreCommandHandlers : IRequestHandler<ImportFileProvinceCommand, Result>,
        IRequestHandler<ImportFileScoreCommand, Result>
    {

        private readonly ICSVHelper _cSVHelper;
        private readonly IExamScoreService _examScoreService;
        private readonly IMapper _mapper;

        public ExamScoreCommandHandlers(ICSVHelper cSVHelper, IExamScoreService examScoreService, IMapper mapper)
        {
            _cSVHelper = cSVHelper;
            _examScoreService = examScoreService;
            _mapper = mapper;
        }

        public async Task<Result> Handle(ImportFileProvinceCommand request, CancellationToken cancellationToken)
        {
            var provinceCities = _cSVHelper.ReadCsv<ProvinceCity>(request.File);

            var result = await _examScoreService.ImportProvinceCity(provinceCities);

            return Result.Success(result);
        }

        public async Task<Result> Handle(ImportFileScoreCommand request, CancellationToken cancellationToken)
        {
            var examScores = _cSVHelper.ReadCsv<ExamScoreDTO>(request.File);
            var examScoresMapper = _mapper.Map<List<ExamScore2024>>(examScores);

            var result = await _examScoreService.ImportCsv(examScoresMapper);

            return Result.Success(result);
        }
    }
}
