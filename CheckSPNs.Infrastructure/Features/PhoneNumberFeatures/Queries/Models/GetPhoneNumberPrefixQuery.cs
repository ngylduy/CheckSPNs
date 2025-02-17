﻿using CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Results;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Models
{
    public class GetPhoneNumberPrefixQuery : IRequest<Result<List<GetListPrefixResponse>>>
    {
    }
}
