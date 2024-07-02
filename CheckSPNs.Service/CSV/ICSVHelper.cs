using Microsoft.AspNetCore.Http;

namespace CheckSPNs.Service.CSV;

public interface ICSVHelper
{
    List<T> ReadCsv<T>(IFormFile file) where T : class;
}
