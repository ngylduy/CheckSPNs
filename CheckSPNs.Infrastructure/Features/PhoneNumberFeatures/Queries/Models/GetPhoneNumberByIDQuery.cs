using CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Results;
using CheckSPNs.Service.Application.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Models
{
    public class GetPhoneNumberByIDQuery : IRequest<Result<GetSinglePhoneNumberResponse>>
    {
        public Guid Id { get; set; }
    }
}
