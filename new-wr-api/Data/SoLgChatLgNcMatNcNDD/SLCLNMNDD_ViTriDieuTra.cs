﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using new_wr_api.Dto;

namespace new_wr_api.Data
{
    public class SLCLNMNDD_ViTriDieuTra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaViTriDieuTra { get; set; }
        public int? ViTriVungDieuTra_ToaDoX { get; set; }
        public int? ViTriVungDieuTra_ToaDoY { get; set; }
        public string? ViTriCongTrinhXaThaiVaoNguonNuoc { get; set; }
        public int? ToaDoViTriXaThai_ToaDoX { get; set; }
        public int? ToaDoViTriXaThai_ToaDoY { get; set; }
    }
}
