using CheckSPNs.Domain.Models.EF.Enums;
using CheckSPNs.Service.Application.Shared;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Commands.Models
{
    public class AddOverallReportPhoneNumberCommand : IRequest<Result>
    {
        [Required]
        public string PhoneNumber { get; set; }
        public PhoneNumberOverallReportEnum reportEnum { get; set; }
    }
}
