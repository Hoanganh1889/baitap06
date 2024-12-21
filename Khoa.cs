namespace BaiTap6
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Khoa")]
    public partial class Khoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Khoa()
        {
            SinhVien = new HashSet<SinhVien>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int maKhoa { get; set; }

        [StringLength(200)]
        public string tenKhoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SinhVien> SinhVien { get; set; }
    }
}
