﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace new_wr_api.Data
{
    public class GS_DuLieu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ConstructionCode { get; set; }
        public string? StationCode { get; set; }
        public string? ParameterName { get; set; }
        public double? Value { get; set; }
        public string? Unit { get; set; }
        public DateTime? Time { get; set; }
        public int? DeviceStatus { get; set; }
        public bool? Status { get; set; }
    }
}
