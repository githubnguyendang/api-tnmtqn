using new_wr_api.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace new_wr_api.Dto
{
    public class CT_ThongTinDto
    {
        public int? Id { get; set; }
        public int? IdLoaiCT { get; set; }
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
        public List<ViTriDto>? vitri { get; set; }
        public List<GP_ThongTinDto>? giayphep { get; set; }
        public List<LuuLuongTheoMucDichDto>? luuluongtheo_mucdich { get; set; }
    }

    public class CT_ThongTinDto_Save
    {
        public int? Id { get; set; }
        public int? IdLoaiCT { get; set; }
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


        public TangChuaNuoc? TangChuaNuoc { get; set; }
        public CT_Loai? LoaiCT { get; set; }
        public LuuVucSong? LuuVuc { get; set; }
        public MucDichKT? MucDichKTSD { get; set; }
        public CT_ThongSo? ThongSo { get; set; }
        public List<CT_HangMuc>? HangMuc { get; set; }
        public List<GP_ThongTin>? GiayPhep { get; set; }
        public List<LuuLuongTheoMucDich>? LuuLuongTheoMucDich { get; set; }
        public List<CT_ViTri>? CT_ViTri { get; set; }
    }
}
