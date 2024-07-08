namespace CheckSPNs.Infrastructure.Features.IdentityFeatures.Authentication.Queries.Results
{
    public class AuthenticatedResponse
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
