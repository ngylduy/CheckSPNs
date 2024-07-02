using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CheckSPNs.Domain.Models.MongoDb.CheckExamScore
{
    public class ExamScore
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Key]
        [Required]
        public string? StudentId { get; set; }
        [Range(0, 10)]
        public float Toan { get; set; }
        [Range(0, 10)]
        public float NguVan { get; set; }
        [Range(0, 10)]
        public float NgoaiNgu { get; set; }
        [Range(0, 10)]
        public float VatLi { get; set; }
        [Range(0, 10)]
        public float HoaHoc { get; set; }
        [Range(0, 10)]
        public float SinhHoc { get; set; }
        [Range(0, 10)]
        public float LichSu { get; set; }
        [Range(0, 10)]
        public float DiaLi { get; set; }
        [Range(0, 10)]
        public float Gdcd { get; set; }
        public string? MaNgoaiNgu { get; set; }
    }
}
