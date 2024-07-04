using AutoMapper;
using CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Queries.Models;
using CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Queries.Results;
using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.MongoDb.Abstract;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Queries.Handlers
{
    public class ExamScoreQueryHandler : IRequestHandler<GetExamScoreByIDQuery, Result<GetSingleExamScoreResponse>>
    {
        private readonly IExamScoreService _examScoreService;
        private readonly IMapper _mapper;

        public ExamScoreQueryHandler(IExamScoreService examScoreService, IMapper mapper)
        {
            _examScoreService = examScoreService;
            _mapper = mapper;
        }

        public async Task<Result<GetSingleExamScoreResponse>> Handle(GetExamScoreByIDQuery request, CancellationToken cancellationToken)
        {
            var examScore = await _examScoreService.GetExamScoreByIdAsync(request.Id);
            var examScoreMapper = _mapper.Map<GetSingleExamScoreResponse>(examScore);
            return Result.Success(examScoreMapper);
        }
    }
}
