using CsvHelper.Configuration.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace CheckSPNs.Domain.Models.MongoDb.CheckExamScore
{
    public class ProvinceCity
    {
        [BsonId]
        [Name("ProvinceCityCode")]
        public string ProvinceCityCode { get; set; }
        [Name("ProvinceCityName")]
        public string ProvinceCityName { get; set; }
    }
}
