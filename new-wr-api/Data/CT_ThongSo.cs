﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace new_wr_api.Data
{
    public class CT_ThongSo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdCT { get; set; }
        public int? IdHangMucCT { get; set; }
        public double? DienTichLuuVuc { get; set; }
        public double? MuaTrungBinhNam { get; set; }
        public double? QTrungBinhNam { get; set; }
        public double? CongSuatLM { get; set; }
        public double? CongSuatDamBao { get; set; }
        public double? ChieuCaoDap { get; set; }
        public double? ChieuDaiDap { get; set; }
        public double? CaoTrinhDap { get; set; }
        public double? QmaxNM { get; set; }
        public double? Qtt { get; set; }
        public double? QDamBao { get; set; }
        public double? Hmax { get; set; }
        public double? Hmin { get; set; }
        public double? HtoiThieu { get; set; }
        public double? MNC { get; set; }
        public double? MNDBT { get; set; }
        public double? MNLTK { get; set; }
        public double? MNLKT { get; set; }
        public double? DungTichToanBo { get; set; }
        public double? DungTichChet { get; set; }
        public double? DungTichHuuIch { get; set; }
        public double? CaoTrinhCong { get; set; }
        public double? ChieuDaiCong { get; set; }
        public double? ChieuRongCong { get; set; }
        public double? KichThuocCong { get; set; }
        public double? SoLuongMayBom { get; set; }
        public double? QThietKe { get; set; }
        public double? QThucTe { get; set; }
        public double? DienTichTuoiThietKe { get; set; }
        public double? DienTichTuoiThucTe { get; set; }
        public double? ThoiGianBomTB { get; set; }
        public double? ThoiGianBomNhoNhat { get; set; }
        public double? ThoiGianBomLonNhat { get; set; }
        public double? ChieuSauDoanThuNuocTu { get; set; }
        public double? ChieuSauDoanThuNuocDen { get; set; }
        public double? QKTCapNuocSinhHoat { get; set; }
        public double? Hgieng { get; set; }
        public double? HGiengKT { get; set; }
        public double? MucNuocTinh { get; set; }
        public double? MucNuocDong { get; set; }
        public double? TangChuaNuocKT { get; set; }
        public double? HHaThap { get; set; }
        public double? LuongNuocKT { get; set; }
        public double? HDatOngLocTu { get; set; }
        public double? HDatOngLocDen { get; set; }
        public double? QKTLonNhat { get; set; }
        public double? CongSuatBom { get; set; }
        public double? QXaThaiTB { get; set; }
        public double? QXaThaiLonNhat { get; set; }
        public double? KqKf { get; set; }
        public double? QXaTran { get; set; }
        public double? QLonNhatTruocLu { get; set; }
        public double? Hlu { get; set; }
        public double? HThuongLuu { get; set; }
        public double? HHaLuu { get; set; }
        public double? QBomThietKe { get; set; }
        public double? QBomLonNhat { get; set; }
        public double? HBeHut { get; set; }
        public double? QXaThai { get; set; }
        public double? QMaxXaThai { get; set; }
        public double? QKhaiThac { get; set; }
        public double? QMaxKT { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdCT")]
        public virtual CT_ThongTin? CongTrinh { get; set; }

        [ForeignKey("IdHangMucCT")]
        public virtual CT_HangMuc? HangMuc { get; set; }
    }
}
