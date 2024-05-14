using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace new_wr_api.Data
{
    public class LuuLuongDto
    {
        public int Id { get; set; }
        public double? LuuLuong { get; set; }
        public string? DonViDo { get; set; }
    }

    public class MucDichKTDto
    {
        public int Id { get; set; }
        public string? MucDich { get; set; }

        public List<LuuLuongDto>? LuuLuong { get; set; }
    }
}
