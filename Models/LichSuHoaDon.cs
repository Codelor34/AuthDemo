using System;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class LichSuHoaDon : ThongTinChung
    {
        [Key]
        public Guid BillHistoryID { get; set; } // giữ nguyên
        [Required]
        public Guid BillID { get; set; } // giữ nguyên
        [StringLength(50)]
        public string BillCode { get; set; } // giữ nguyên
        [Required]
        public Guid UserID { get; set; } // giữ nguyên
        [StringLength(100)]
        public string HoTen { get; set; }
        [StringLength(255)]
        public string DiaChiCu { get; set; }
        [StringLength(255)]
        public string DiaChiMoi { get; set; }
        [StringLength(50)]
        public string TrangThaiCu { get; set; }
        [StringLength(50)]
        public string TrangThaiMoi { get; set; }
        [StringLength(255)]
        public string GhiChu { get; set; }
        public HoaDon HoaDon { get; set; }
        public NguoiDung NguoiDung { get; set; }
    }
} 