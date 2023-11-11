﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using new_wr_api.Dto;

namespace new_wr_api.Data
{
    public class DMSS_DiemDauSongSuoi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDiemDauSong_Suoi { get; set; }
        public double? DiemDauSong_Suoi_ToaDoX { get; set; }
        public double? DiemDauSong_Suoi_ToaDoY { get; set; }
        public string? DiemDauSong_Suoi_Thon_Ban { get; set; }
        public string? DiemDauSong_Suoi_Xa_Phuong_ThiTran { get; set; }
        public string? DiemDauSong_Suoi_Huyen_ThanhPho { get; set; }
    }
}
