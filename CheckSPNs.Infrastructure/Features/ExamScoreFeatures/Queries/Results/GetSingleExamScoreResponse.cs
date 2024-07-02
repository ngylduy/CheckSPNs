namespace CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Queries.Results
{
    public class GetSingleExamScoreResponse
    {
        public string? StudentId { get; set; }
        public float? Toan { get; set; }
        public float? NguVan { get; set; }
        public float? NgoaiNgu { get; set; }
        public float? VatLi { get; set; }
        public float? HoaHoc { get; set; }
        public float? SinhHoc { get; set; }
        public float? LichSu { get; set; }
        public float? DiaLi { get; set; }
        public float? Gdcd { get; set; }
        public string? MaNgoaiNgu { get; set; }
        public string? ProvinceCity { get; set; }
    }
}
