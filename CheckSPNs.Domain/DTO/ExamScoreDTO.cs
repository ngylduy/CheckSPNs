using CsvHelper.Configuration.Attributes;

namespace CheckSPNs.Domain.DTO;

public class ExamScoreDTO
{
    [Name("sbd")]
    public string? StudentId { get; set; }
    [Name("toan")]
    public float? Toan { get; set; }
    [Name("ngu_van")]
    public float? NguVan { get; set; }
    [Name("ngoai_ngu")]
    public float? NgoaiNgu { get; set; }
    [Name("vat_li")]
    public float? VatLi { get; set; }
    [Name("hoa_hoc")]
    public float? HoaHoc { get; set; }
    [Name("sinh_hoc")]
    public float? SinhHoc { get; set; }
    [Name("lich_su")]
    public float? LichSu { get; set; }
    [Name("dia_li")]
    public float? DiaLi { get; set; }
    [Name("gdcd")]
    public float? Gdcd { get; set; }
    [Name("ma_ngoai_ngu")]
    public string? MaNgoaiNgu { get; set; }

    [Ignore]
    public string? ProvinceCity { get; set; }
}
