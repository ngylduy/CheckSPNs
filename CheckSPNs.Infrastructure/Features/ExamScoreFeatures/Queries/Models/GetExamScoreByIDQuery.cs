using CheckSPNs.Infrastructure.Bases;
using CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Queries.Results;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Queries.Models
{
    public class GetExamScoreByIDQuery : IRequest<Response<GetSingleExamScoreResponse>>
    {
        public GetExamScoreByIDQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; } = null!;
    }
}
