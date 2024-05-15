﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace new_wr_api.Data
{
    public class DanhMucNN_LienTinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? MaSong1 { get; set; }
        public string? MaSong2 { get; set; }
        public string? MaSong3 { get; set; }
        public string? MaSong4 { get; set; }
        public string? MaSong5 { get; set; }
        public string? TenSongSuoi { get; set; }
        public string? ChayRa { get; set; }
        public double? XDiemDau { get; set; }
        public double? YDiemDau { get; set; }
        public string? ThonDiemDau { get; set; }
        public string? XaPhuongTTDiemDau { get; set; }
        public string? HuyenTPDiemDau { get; set; }
        public double? XDiemCuoi { get; set; }
        public double? YDiemCuoi { get; set; }
        public string? ThonDiemCuoi { get; set; }
        public string? XaPhuongTTDiemCuoi { get; set; }
        public string? HuyenTPDiemCuoi { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
