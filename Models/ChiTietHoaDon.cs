using System;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class ChiTietHoaDon : ThongTinChung
    {
        [Key]
        public Guid BillDetailID { get; set; } // giữ nguyên
        [Required]
        public Guid BillID { get; set; } // giữ nguyên
        [Required]
        public Guid ShoeDetailID { get; set; } // giữ nguyên
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal? ChietKhauPhanTram { get; set; } // % chiết khấu dòng (nullable)
        public decimal? ChietKhauTienMat { get; set; }  // Số tiền chiết khấu dòng (nullable)
        public bool? IsTangKem { get; set; }            // true nếu là sản phẩm tặng (nullable)
        public HoaDon HoaDon { get; set; }
        public ChiTietGiay ChiTietGiay { get; set; }
    }
} 