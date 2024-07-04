using CheckSPNs.Infrastructure.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Commands.Models
{
    public class ImportFileProvinceCommand : IRequest<Result>
    {
        public IFormFile File { get; }

        public ImportFileProvinceCommand(IFormFile file)
        {
            File = file;
        }
    }
}
