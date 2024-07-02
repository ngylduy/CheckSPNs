using AutoMapper;
using CheckSPNs.Infrastructure.Bases;
using CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Queries.Models;
using CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Queries.Results;
using CheckSPNs.Service.MongoDb.Abstract;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Queries.Handlers
{
    public class ExamScoreQueryHandler : ResponseHandler,
        IRequestHandler<GetExamScoreByIDQuery, Response<GetSingleExamScoreResponse>>
    {
        private readonly IExamScoreService _examScoreService;
        private readonly IMapper _mapper;

        public ExamScoreQueryHandler(IExamScoreService examScoreService, IMapper mapper)
        {
            _examScoreService = examScoreService;
            _mapper = mapper;
        }

        public async Task<Response<GetSingleExamScoreResponse>> Handle(GetExamScoreByIDQuery request, CancellationToken cancellationToken)
        {
            var examScore = await _examScoreService.GetExamScoreByIdAsync(request.Id);
            var examScoreMapper = _mapper.Map<GetSingleExamScoreResponse>(examScore);
            var result = Success(examScoreMapper);
            return result;
        }
    }
}
