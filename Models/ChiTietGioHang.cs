using System;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class ChiTietGioHang : ThongTinChung
    {
        [Key]
        public Guid CartDetailID { get; set; } // giữ nguyên
        [Required]
        public Guid CartID { get; set; } // giữ nguyên
        
        [Required]
        public Guid ShoeDetailID { get; set; } // giữ nguyên
        public int SoLuong { get; set; }
        [StringLength(50)]
        public string KichThuoc { get; set; }
        public GioHang GioHang { get; set; }
        public ChiTietGiay ChiTietGiay { get; set; }
        public decimal? ChietKhauPhanTram { get; set; } // % chiết khấu dòng (nullable)
        public decimal? ChietKhauTienMat { get; set; }  // Số tiền chiết khấu dòng (nullable)
        public bool? IsTangKem { get; set; }            // true nếu là sản phẩm tặng (nullable)
        public string? LyDo { get; set; }
    }
} 