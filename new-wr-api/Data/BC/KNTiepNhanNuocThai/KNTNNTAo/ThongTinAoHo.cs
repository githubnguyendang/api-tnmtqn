using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace new_wr_api.Data
{
    public class ThongTinAoHo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdHoChua{ get; set; }
        public int IdCLNQC { get; set; }

        //ketqua
        public double? CnnBOD { get; set; }
        public double? CnnCOD { get; set; }
        public double? CnnAmoni { get; set; }
        public double? CnnTongN { get; set; }
        public double? CnnTongP { get; set; }
        public double? CnnTSS { get; set; }
        public double? CnnColiform { get; set; }

        public double? MtnBOD { get; set; }
        public double? MtnCOD { get; set; }
        public double? MtnAmoni { get; set; }
        public double? MtnTongN { get; set; }
        public double? MtnTongP { get; set; }
        public double? MtnTSS { get; set; }
        public double? MtnColiform { get; set; }

        public string? GhiChu { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdHoChua")]
        public virtual CT_ThongTin? CT_ThongTin { get; set; }

        [ForeignKey("IdCLNQC")]
        public virtual ThongSoCLNAo? ThongSoCLNAo { get; set; }
    }
}
