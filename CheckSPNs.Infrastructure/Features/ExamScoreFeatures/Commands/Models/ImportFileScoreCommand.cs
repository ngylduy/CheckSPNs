using CheckSPNs.Infrastructure.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Commands.Models
{
    public class ImportFileScoreCommand : IRequest<Result>
    {
        public IFormFile File { get; }

        public ImportFileScoreCommand(IFormFile file)
        {
            File = file;
        }
    }
}
