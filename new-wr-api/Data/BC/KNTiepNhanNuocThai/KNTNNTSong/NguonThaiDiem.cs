﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace new_wr_api.Data
{
    public class NguonThaiDiem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Loai { get; set; }
        public string? Ten { get; set; }
        public double? ToaDoX { get; set; }
        public double? ToaDoY { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
