namespace CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Queries.Results;


public class GetTypeOfReportListResponse
{
    public Guid Id { get; set; }
    public string TypeOfReport { get; set; } = null!;
}
