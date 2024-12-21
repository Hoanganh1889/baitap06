namespace BaiTap6
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [Key]
        [StringLength(20)]
        public string maSV { get; set; }

        [Required]
        [StringLength(200)]
        public string hoTen { get; set; }

        public double? diemTB { get; set; }

        public int? maKhoa { get; set; }

        public virtual Khoa Khoa { get; set; }
    }
}
