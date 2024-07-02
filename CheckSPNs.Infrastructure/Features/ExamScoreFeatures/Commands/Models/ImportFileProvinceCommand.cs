using CheckSPNs.Infrastructure.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Commands.Models
{
    public class ImportFileProvinceCommand : IRequest<Response<string>>
    {
        public IFormFile File { get; }

        public ImportFileProvinceCommand(IFormFile file)
        {
            File = file;
        }
    }
}
