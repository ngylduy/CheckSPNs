﻿using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Models
{
    public class GetPhoneNumberQuery : IRequest<Result<PhoneNumbers>>
    {
        string PhoneNumber { get; set; }
    }
}
