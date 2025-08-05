using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; // Added for ICollection

namespace AuthDemo.Models
{
    public class GioHang : ThongTinChung
    {
        [Key]
        public Guid CartID { get; set; } // giữ nguyên
        [Required]
        public Guid UserID { get; set; } // giữ nguyên
        public NguoiDung NguoiDung { get; set; } // Added navigation property
        public ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; } // Added navigation property
    }
} 