namespace new_wr_api.Dto
{
    public class TramQuangNgaiDto
    {
        public int? Id { get; set; }
        public string? ThoiGian { get; set; }
        public double? LuongMua { get; set; }
        public double? NhietDo { get; set; }
        public double? DoAm { get; set; }
        public double? TocDoGio { get; set; }
    }
    public class ApexChartSeriesTramDto
    {
        public string? name { get; set; }
        public List<double>? data { get; set; }
    }
}