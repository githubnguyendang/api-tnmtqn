using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace new_wr_api.Data
{
    public class GP_ThongTin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        // Navigation property to represent the relationship
        [ForeignKey("IdLoaiGP")]
        public virtual GP_Loai? LoaiGP { get; set; }

        [ForeignKey("IdCT")]
        public virtual CT_ThongTin? CongTrinh { get; set; }

        [ForeignKey("IdTCCN")]
        public virtual ToChuc_CaNhan? ToChuc_CaNhan { get; set; }

        public virtual ICollection<GP_TCQ>? GP_TCQ { get; set; }
    }
}
