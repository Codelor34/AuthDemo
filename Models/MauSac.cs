using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AuthDemo.Models
{
    public class MauSac : ThongTinChung
    {
        [Key]
        public Guid ColorID { get; set; } // giữ nguyên
        [StringLength(50)]
        public string TenMau { get; set; }
        [StringLength(50)]
        public string MaMau { get; set; }
        public ICollection<ChiTietGiay>? ChiTietGiays { get; set; }
    }
} 