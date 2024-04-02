namespace new_wr_api.Dto
{
    public class ThongTinAoHoDto
    {
        public int Id { get; set; }
        public int IdHoChua { get; set; }
        public int IdCLNQC { get; set; }

        //ketqua
        public double? CnnBOD { get; set; }
        public double? CnnCOD { get; set; }
        public double? CnnAmoni { get; set; }
        public double? CnnTongN { get; set; }
        public double? CnnTongP { get; set; }
        public double? CnnTSS { get; set; }
        public double? CnnColiform { get; set; }

        //Mtn
        public double? MtnBOD { get; set; }
        public double? MtnCOD { get; set; }
        public double? MtnAmoni { get; set; }
        public double? MtnTongN { get; set; }
        public double? MtnTongP { get; set; }
        public double? MtnTSS { get; set; }
        public double? MtnColiform { get; set; }
        public string? GhiChu { get; set; }
        public bool? DaXoa { get; set; }
    }
}
