namespace De01.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            SPTheoMaus = new HashSet<SPTheoMau>();
        }

        [Key]
        public int MaSanPham { get; set; }

        [StringLength(20)]
        [DisplayName("T�n s?n ph?m")]
        public string TenSanPham { get; set; }
        [DisplayName("Ph�n lo?i")]

        public int? MaPhanLoai { get; set; }

        [StringLength(100)]
        [DisplayName("G�a nh?p")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ch? ???c nh?p s? ")]

        public string GiaNhap { get; set; }

        [StringLength(10)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ch? ???c nh?p s? ")]
        [DisplayName("Gi� nh? nh�t")]

        public string DonGiaBanNhoNhat { get; set; }

        [StringLength(10)]
        [DisplayName("Gi� cao nh�t")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Ch? ???c nh?p s? ")]

        public string DonGiaBanLonNhat { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Tr?ng th�i")]

        public string TrangThai { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("M� t? ng?n")]

        public string MoTaNgan { get; set; }

        [StringLength(100)]
        [DisplayName("?nh ??i di?n")]

        public string AnhDaiDien { get; set; }

        [StringLength(200)]
        [DisplayName("N?i b?t")]

        public string NoiBat { get; set; }
        [DisplayName("Ph�n loai ph?")]


        public int? MaPhanLoaiPhu { get; set; }

        public virtual PhanLoai PhanLoai { get; set; }

        public virtual PhanLoaiPhu PhanLoaiPhu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPTheoMau> SPTheoMaus { get; set; }
    }
}
