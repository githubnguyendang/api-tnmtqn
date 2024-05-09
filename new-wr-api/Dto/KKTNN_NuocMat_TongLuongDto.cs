using new_wr_api.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace new_wr_api.Dto
{
    public class KKTNN_NuocMat_TongLuongDto
    {
        public int? Id { get; set; }
        public int? IdLuuVucSong { get; set; }
        public int? Nam { get; set; }
        public double? Thang1 { get; set; }
        public double? Thang2 { get; set; }
        public double? Thang3 { get; set; }
        public double? Thang4 { get; set; }
        public double? Thang5 { get; set; }
        public double? Thang6 { get; set; }
        public double? Thang7 { get; set; }
        public double? Thang8 { get; set; }
        public double? Thang9 { get; set; }
        public double? Thang10 { get; set; }
        public double? Thang11 { get; set; }
        public double? Thang12 { get; set; }
        public LuuVucSong? LuuVucSong { get; set; }
        public ViTriDto? vitri { get; set; }
    }
}
