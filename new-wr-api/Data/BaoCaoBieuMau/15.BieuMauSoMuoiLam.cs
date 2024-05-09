using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace new_wr_api.Data
{
    public class BieuMauSoMuoiLam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? CoQuanPhatHanh { get; set; }
        public double? VanBanKyTruoc { get; set; }
        public double? VanBanKyBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }
}
