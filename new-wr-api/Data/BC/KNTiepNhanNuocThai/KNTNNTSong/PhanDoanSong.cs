using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace new_wr_api.Data.BC.KNTiepNhanNuocThai.KNTNNTSong
{
    public class PhanDoanSong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? LuuVucSong { get; set; }
        public string? Song { get; set; }
        public string? TenDoanSong { get; set; }
        public string? PhanDoan { get; set; }
        public double? ChieuDai { get; set; }
        public double? DienTichLV { get; set; }
        public double? XDau { get; set; }
        public double? YDau { get; set; }
        public double? XCuoi { get; set; }
        public double? YCuoi { get; set; }
        public string? DiaGioiHanhChinh { get; set; }
        public string? MucDichSuDung { get; set; }
        public string? ChatLuongNuoc { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
        public virtual DuLieuNguonNuocThaiDiem? DuLieuNguonNuocThaiDiem { get; set; }
        public virtual DuLieuNguonNuocThaiSinhHoat? DuLieuNguonNuocThaiSinhHoat { get; set; }

    }
}
