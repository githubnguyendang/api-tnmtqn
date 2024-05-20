using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using new_wr_api.Dto;

namespace new_wr_api.Data
{
    public class MucDichKTDto
    {
        public int? Id { get; set; }
        public string? MucDich { get; set; }
        public bool? DaXoa { get; set; } = false;
        public LuuLuongTheoMucDichDto? LuuLuong { get; set; }
    }
}
