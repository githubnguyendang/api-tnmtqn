using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace new_wr_api.Data
{
    public class CLN_NuocMat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? LuuVucSong { get; set; }
        public DateTime? ThoiGianQuanTrac { get; set; }
        public string? SongSuoiHoChua { get; set; }
        public string? ViTriQuanTrac { get; set; }
        public double? PhMax { get; set; }
        public double? PhMin { get; set; }
        public double? BOD5Max { get; set; }
        public double? BOD5Min { get; set; }
        public double? CODMax { get; set; }
        public double? CODMin { get; set; }
        public double? TSSMax { get; set; }
        public double? TSSMin { get; set; }
        public double? DOMax { get; set; }
        public double? DOMin { get; set; }
        public double? PhosphorTPMax { get; set; }
        public double? PhosphorTPMin { get; set; }
        public double? NitoTNMax { get; set; }
        public double? NitoTNMin { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
