namespace new_wr_api.Dto
{
    public class DiemQuanTracDto
    {
        public int Id { get; set; }
        public int TenDiemDo { get; set; }
        public double ToaDoX { get; set; }
        public double ToaDoY { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
