using CheckSPNs.Infrastructure.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Commands.Models
{
    public class ImportFileScoreCommand : IRequest<Response<string>>
    {
        public IFormFile File { get; }

        public ImportFileScoreCommand(IFormFile file)
        {
            File = file;
        }
    }
}
