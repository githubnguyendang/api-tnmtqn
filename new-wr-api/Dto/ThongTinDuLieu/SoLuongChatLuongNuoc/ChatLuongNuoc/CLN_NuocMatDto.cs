namespace new_wr_api.Dto
{
    public class CLN_NuocMatDto
    {
        public int? Id { get; set; }

        public DateTime? ThoiGianQuanTrac { get; set; }
        public string? LuuVucSong { get; set; }
        public string? SongSuoiHoChua { get; set; }
        public string? ViTriQuanTrac { get; set; }
        public double? PhMax { get; set; }
        public double? PhMin { get; set; }
        public double? BOD5Max { get; set; }
        public double? BOD5Min { get; set; }
        public double? CODMax { get; set; }
        public double? CODMin { get; set; }
        public double? TSSMax { get; set; }
        public double? TSSMin { get; set; }
        public double? DOMax { get; set; }
        public double? DOMin { get; set; }
        public double? PhosphorTPMax { get; set; }
        public double? PhosphorTPMin { get; set; }
        public double? NitoTNMax { get; set; }
        public double? NitoTNMin { get; set; }
        public string? GhiChu { get; set; }
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
