namespace new_wr_api.Dto
{
    public class LuuVucSongDto
    {
        public int? Id { get; set; }
        public string? TenLVS { get; set; }
        public string? ChuGiai { get; set; }
        public string? ViTriQT { get; set; }
        public int? NgayBatDau { get; set; }
        public int? NgayKetThuc { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
        public ViTriDto? donvi_hanhchinh { get; set; }
    }
}
