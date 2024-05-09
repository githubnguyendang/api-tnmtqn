using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace new_wr_api.Data
{
    public class BieuMauSoHaiLam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ThongSoQuanTrac { get; set; }
        public double? NongDoLonNhat { get; set; }
        public double? NongDoNhoNhat { get; set; }
        public double? NongDoQuyDinh { get; set; }
        public string? GhiChu { get; set; }
    }
}
