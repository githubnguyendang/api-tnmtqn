using new_wr_api.Data;

namespace new_wr_api.Dto
{
    public class CT_ThongTinDto
    {
        public int? Id { get; set; }
        public int? IdLoaiCT { get; set; }
        public string? IdHuyen { get; set; }
        public string? IdXa { get; set; }
        public int? IdSong { get; set; }
        public int? IdLuuVuc { get; set; }
        public int? IdTieuLuuVuc { get; set; }
        public int? IdTangChuaNuoc { get; set; }
        public string? TenCT { get; set; }
        public string? MaCT { get; set; }
        public string? ViTriCT { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public string? CapCT { get; set; }
        public int? NamBatDauVanHanh { get; set; }
        public string? NguonNuocKT { get; set; }
        public string? MucDichKT { get; set; }
        public string? PhuongThucKT { get; set; }
        public string? NguonNuocXT { get; set; }
        public string? ThoiGianKT { get; set; }
        public string? ThoiGianHNK { get; set; }
        public string? MucDichHNK { get; set; }
        public string? MucDichhTD { get; set; }
        public string? QuyMoHNK { get; set; }
        public string? ThoiGianXD { get; set; }
        public int? SoLuongGiengKT { get; set; }
        public int? SoLuongGiengQT { get; set; }
        public int? SoDiemXaThai { get; set; }
        public int? SoLuongGieng { get; set; }
        public int? KhoiLuongCacHangMucTD { get; set; }
        public int? QKTThietKe { get; set; }
        public int? QKTThucTe { get; set; }
        public string? ViTriXT { get; set; }
        public string? TaiKhoan { get; set; }
        public string? ChuThich { get; set; }
        public bool? DaXoa { get; set; }

        public CT_LoaiDto? loaiCT { get; set; }
        public List<CT_HangMucDto>? hangmuc { get; set; }
        public CT_ThongSoDto? thongso { get; set; }
        public DonViHCDto? donvi_hanhchinh { get; set; }
        public HuyenDto? huyen { get; set; }
        public XaDto? xa { get; set; }
        public List<GP_ThongTinDto>? giayphep { get; set; }
        public List<LuuLuongTheoMucDichDto>? luuluongtheo_mucdich { get; set; }
    }
}
