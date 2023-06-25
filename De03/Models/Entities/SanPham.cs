namespace De03.Models.Entities
{
    using System;
    using System.Collections.Generic;
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

        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9\s]*$", ErrorMessage = "Ten san pham phai bat dau bang 1 chu cai")]
        public string TenSanPham { get; set; }

        public int? MaPhanLoai { get; set; }

        [StringLength(100)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Chi duoc nhap so ")]
        public string GiaNhap { get; set; }

        [StringLength(10)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Chi duoc nhap so ")]
        public string DonGiaBanNhoNhat { get; set; }

        [StringLength(10)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Chi duoc nhap so ")]
        public string DonGiaBanLonNhat { get; set; }

        [Column(TypeName = "ntext")]
        public string TrangThai { get; set; }

        [Column(TypeName = "ntext")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9\s]*$", ErrorMessage = "Mo ta ngan phai bat dau 1 chu cai")]
        public string MoTaNgan { get; set; }

        [StringLength(100)]
        [RegularExpression(@"^.*\.png$", ErrorMessage = "Ten file anh co pham mo rong la '.png'.")]
        public string AnhDaiDien { get; set; }

        [StringLength(200)]
        public string NoiBat { get; set; }

        public int? MaPhanLoaiPhu { get; set; }

        public virtual PhanLoai PhanLoai { get; set; }

        public virtual PhanLoaiPhu PhanLoaiPhu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPTheoMau> SPTheoMaus { get; set; }
    }
}
