﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace new_wr_api.Data
{
    public class ThongSoCLNAo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? pH { get; set; }
        public string? BOD { get; set; }
        public string? COD { get; set; }
        public string? TOC { get; set; }
        public string? TSS { get; set; }
        public string? DO { get; set; }
        public string? TongPhosphor { get; set; }
        public string? TongNito { get; set; }
        public string? Chiorophylla { get; set; }
        public string? TongColiform { get; set; }
        public string? ColiformChiuNhiet { get; set; }
        public string? MucPLCLNuoc { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
