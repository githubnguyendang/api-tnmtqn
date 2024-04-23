namespace new_wr_api.Dto
{
    public class CLN_NuocMatDto
    {
        public int Id { get; set; }
        public string? LuuVucSong { get; set; }
        public int? ThoiGianQuanTrac { get; set; }
        public string? SongSuoiHoChua { get; set; }
        public string? ViTriQuanTrac { get; set; }
        public string? KyHieuDiemQuanTrac { get; set; }
        public double? PhDot1 { get; set; }
        public double? PhDot2 { get; set; }
        public double? PhDot3 { get; set; }
        public double? BOD5Dot1 { get; set; }
        public double? BOD5Dot2 { get; set; }
        public double? BOD5Dot3 { get; set; }
        public double? CODDot1 { get; set; }
        public double? CODDot2 { get; set; }
        public double? CODDot3 { get; set; }
        public double? DODot1 { get; set; }
        public double? DODot2 { get; set; }
        public double? DODot3 { get; set; }
        public double? PhotphoDot1 { get; set; }
        public double? PhotphoDot2 { get; set; }
        public double? PhotphoDot3 { get; set; }
        public double? NitoDot1 { get; set; }
        public double? NitoDot2 { get; set; }
        public double? NitoDot3 { get; set; }
    }

    public class CLN_NDDDto
    {
        public int? Id { get; set; }
        public string? LuuVucSong { get; set; }
        public string? SongSuoiHoChua { get; set; }
        public string? ViTriQuanTrac { get; set; }
        public double? PhMax { get; set; }
        public double? PhMin { get; set; }
        public double? ColiformMax { get; set; }
        public double? ColiformMin { get; set; }
        public double? NitrateMax { get; set; }
        public double? NitrateMin { get; set; }
        public double? AmoniMax { get; set; }
        public double? AmoniMin { get; set; }
        public double? TDSMax { get; set; }
        public double? TDSMin { get; set; }
        public double? DoCungMax { get; set; }
        public double? DoCungMin { get; set; }
        public double? ASMax { get; set; }
        public double? ASMin { get; set; }
        public double? ChlorideMax { get; set; }
        public double? ChlorideMin { get; set; }
        public string? GhiChu { get; set; }
    }
}
