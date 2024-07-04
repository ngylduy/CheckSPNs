using CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Queries.Results;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Queries.Models
{
    public class GetExamScoreByIDQuery : IRequest<Result<GetSingleExamScoreResponse>>
    {
        public GetExamScoreByIDQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; } = null!;
    }
}
