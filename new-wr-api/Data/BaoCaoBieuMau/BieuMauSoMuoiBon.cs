using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace new_wr_api.Data
{
    public class BieuMauSoMuoiBon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ViTriQuanTrac { get; set; }
        public string? LuuVucSong { get; set; }
        public string? TangChuaNuoc { get; set; }
        public double? PHlonNhat { get; set; }
        public double? PHNhoNhat { get; set; }
        public double? ColiformlonNhat { get; set; }
        public double? ColiformNhoNhat { get; set; }
        public double? NitratelonNhat { get; set; }
        public double? NitrateNhoNhat { get; set; }
        public double? AmonilonNhat { get; set; }
        public double? AmoniNhoNhat { get; set; }
        public double? TDSlonNhat { get; set; }
        public double? TDSNhoNhat { get; set; }
        public double? DoCungLonNhat { get; set; }
        public double? DoCungNhoNhat { get; set; }
        public double? ArsenicLonNhat { get; set; }
        public double? ArsenicNhoNhat { get; set; }
        public double? ChlorideLonNhat { get; set; }
        public double? ChlorideNhoNhat { get; set; }
        public string? GhiChu { get; set; }
    }
}
