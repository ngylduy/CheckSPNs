namespace CheckSPNs.Client.Data;

public static class ApiBase
{
    public static string? APIBaseUrl { get; set; }
    public enum APIType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}

