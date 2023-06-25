namespace De07.Models.Entities
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
        //  [RegularExpression(@"^[a-zA-Z]", ErrorMessage = "Ten phai bat dau chu cai ")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9\s]*$", ErrorMessage = "Ten ph?i b?t ??u b?ng m?t ch? cái")]
        public string TenSanPham { get; set; }

        public int? MaPhanLoai { get; set; }

        [StringLength(100)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "B?n ch? ???c nh?p s? nguyên d??ng.")]
        
        public string GiaNhap { get; set; }

        [StringLength(10)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "B?n ch? ???c nh?p s? nguyên d??ng.")]
        public string DonGiaBanNhoNhat { get; set; }

        [StringLength(10)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "B?n ch? ???c nh?p s? nguyên d??ng.")]
        public string DonGiaBanLonNhat { get; set; }

        [Column(TypeName = "ntext")]
        public string TrangThai { get; set; }

        [Column(TypeName = "ntext")]
        //  [RegularExpression(@"^[a-zA-Z]", ErrorMessage = "Mô t? ng?n ph?i b?t ??u b?ng m?t ch? cái")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9\s]*$", ErrorMessage = "Mô t? ng?n ph?i b?t ??u b?ng m?t ch? cái")]

        public string MoTaNgan { get; set; }

        [StringLength(100)]
        [RegularExpression(@"^.*\.jpg$", ErrorMessage = "Tên file ?nh ph?i có ph?n m? r?ng '.jpg'.")]
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
