﻿using new_wr_api.Data;

namespace new_wr_api.Dto
{
    public class GP_ThongTinDto
    {
        public int Id { get; set; }
        public int? IdCon { get; set; }
        public int? IdLoaiGP { get; set; }
        public int? IdTCCN { get; set; }
        public int? IdCT { get; set; }
        public string? TenGP { get; set; }
        public string? SoGP { get; set; }
        public DateTime? NgayCap { get; set; }
        public DateTime? NgayCoHieuLuc { get; set; }
        public DateTime? NgayHetHieuLuc { get; set; }
        public string? ThoiHan { get; set; }
        public string? CoQuanCapPhep { get; set; }
        public string? FileGiayPhep { get; set; }
        public string? FileGiayToLienQuan { get; set; }
        public string? FileDonXinCP { get; set; }
        public bool? DaBiThuHoi { get; set; }

        public CT_ThongTinDto? congtrinh { get; set; }
        public ToChuc_CaNhanDto? tochuc_canhan { get; set; }
    }
}