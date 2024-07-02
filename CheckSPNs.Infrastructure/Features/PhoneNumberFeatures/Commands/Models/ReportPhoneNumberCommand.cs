using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Service.Application.Shared;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Commands.Models
{
    public class ReportPhoneNumberCommand : IRequest<Result<PhoneNumbers>>
    {
        [Required]
        public string PhoneNumber { get; set; }
    }
}
