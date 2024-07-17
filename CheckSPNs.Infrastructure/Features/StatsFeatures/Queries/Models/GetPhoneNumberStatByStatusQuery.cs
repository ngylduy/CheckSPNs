using CheckSPNs.Domain.ViewModel.Stats;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.StatsFeatures.Queries.Models
{
    public class GetPhoneNumberStatByStatusQuery : IRequest<Result<PhoneNumberStatByStatus>>
    {

    }
}
