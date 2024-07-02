using AutoMapper;
using CheckSPNs.Domain.DTO;
using CheckSPNs.Domain.Models.MongoDb.CheckExamScore;
using CheckSPNs.Infrastructure.Bases;
using CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Commands.Models;
using CheckSPNs.Service.CSV;
using CheckSPNs.Service.MongoDb.Abstract;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Commands.Handlers
{
    public class ExamScoreCommandHandlers : ResponseHandler, IRequestHandler<ImportFileProvinceCommand, Response<string>>,
        IRequestHandler<ImportFileScoreCommand, Response<string>>
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

        public async Task<Response<string>> Handle(ImportFileProvinceCommand request, CancellationToken cancellationToken)
        {
            var provinceCities = _cSVHelper.ReadCsv<ProvinceCity>(request.File);

            var result = await _examScoreService.ImportProvinceCity(provinceCities);

            if (result == "Success")
            {
                return Created(result);
            }
            else return BadRequest<string>("Fail!");
        }

        public async Task<Response<string>> Handle(ImportFileScoreCommand request, CancellationToken cancellationToken)
        {
            var examScores = _cSVHelper.ReadCsv<ExamScoreDTO>(request.File);
            var examScoresMapper = _mapper.Map<List<ExamScore>>(examScores);

            var result = await _examScoreService.ImportCsv(examScoresMapper);

            if (result == "Success")
            {
                return Created(result);
            }
            else return BadRequest<string>("Fail!");
        }
    }
}
