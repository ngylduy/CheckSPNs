using CsvHelper;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace CheckSPNs.Service.CSV;

public class CSVHelper : ICSVHelper
{
    public List<T> ReadCsv<T>(IFormFile file) where T : class
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("File is null or empty.");
        }

        try
        {
            using var reader = new StreamReader(file.OpenReadStream());
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<T>().ToList();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error processing CSV file.", ex);
        }
    }
}
