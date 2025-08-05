using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AuthDemo.Models
{
    public class ThuongHieu : ThongTinChung
    {
        [Key]
        public Guid BrandID { get; set; } // giữ nguyên
        [StringLength(50)]
        public string TenThuongHieu { get; set; }
        [StringLength(50)]
        public string MaThuongHieuCode { get; set; }
        public ICollection<ChiTietGiay>? ChiTietGiays { get; set; }
    }
} 