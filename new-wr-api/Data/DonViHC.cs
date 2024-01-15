﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace new_wr_api.Data
{
    public class DonViHC
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TenTinh { get; set; }
        public string? IdTinh { get; set; }
        public string? TenHuyen { get; set; }
        public string? IdHuyen { get; set; }
        public string? TenXa { get; set; }
        public string? IdXa { get; set; }
        public string? CapHanhChinh { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }

    public class Huyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string IdHuyen { get; set; }
        public string? TenHuyen { get; set; }
        public string? CapHanhChinh { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        // Navigation property to represent the one-to-many relationship
        public virtual ICollection<Xa>? Xa { get; set; }

        public virtual ICollection<CT_ThongTin>? CongTrinh { get; set; }
    }

    public class Xa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string IdXa { get; set; }
        public string? TenXa { get; set; }
        public string? CapHanhChinh { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        // Foreign key property
        public string? IdHuyen { get; set; }

        // Navigation property to represent the relationship
        [ForeignKey("IdHuyen")]
        public virtual Huyen? Huyen { get; set; }

        public virtual ICollection<CT_ThongTin>? CongTrinh { get; set; }
    }

}
