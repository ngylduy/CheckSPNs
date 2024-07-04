using CheckSPNs.Infrastructure.Shared;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Commands.Models
{
    public class AddPhoneNumberTypeOfReportCommand : IRequest<Result>
    {
        [Required]
        public string PhoneNumber { get; set; }
        public Guid TypeOfReportsId { get; set; }
    }
}
