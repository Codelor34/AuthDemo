using System;
using System.ComponentModel.DataAnnotations;
using AuthDemo.Models.Enums;

namespace AuthDemo.Models
{
    public class HoaDon : ThongTinChung
    {
        [Key]
        public Guid BillID { get; set; } // giữ nguyên
        [Required]
        public Guid UserID { get; set; } // giữ nguyên
        [StringLength(100)]
        public string HoTen { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(20)]
        public string SoDienThoai { get; set; }
        [StringLength(255)]
        public string DiaChi { get; set; }
        public decimal TongTien { get; set; }
        public TrangThaiHoaDon TrangThai { get; set; }
        public bool DaThanhToan { get; set; }
        public PhuongThucThanhToan PhuongThucThanhToan { get; set; }
        public PhuongThucVanChuyen PhuongThucVanChuyen { get; set; }
        public bool DaHuy { get; set; }
        [StringLength(255)]
        public string GhiChu { get; set; }
        public DateTime? NgayGiaoHang { get; set; }
        [StringLength(255)]
        public string LyDo { get; set; }
        public decimal? GiamGiaPhanTram { get; set; } // % giảm giá toàn hóa đơn (nullable)
        public decimal? GiamGiaTienMat { get; set; }  // Số tiền giảm trực tiếp (nullable)
        public string? LyDoGiamGia { get; set; }      // Lý do giảm giá (nullable)
        public NguoiDung NguoiDung { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public ICollection<LichSuHoaDon> LichSuHoaDons { get; set; }
    }
} 