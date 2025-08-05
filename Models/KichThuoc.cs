using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AuthDemo.Models
{
    public class KichThuoc : ThongTinChung
    {
        [Key]
        public Guid SizeID { get; set; } // giữ nguyên
        [StringLength(50)]
        public string TenKichThuoc { get; set; }
        [StringLength(50)]
        public string MaKichThuocCode { get; set; }
        public ICollection<ChiTietGiay>? ChiTietGiays { get; set; }
    }
} 