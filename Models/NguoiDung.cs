using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class NguoiDung : ThongTinChung
    {
        [Key]
        public Guid UserID { get; set; } // giữ nguyên
        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; } // UserName (not null)
        [Required]
        [StringLength(100)]
        public string MatKhau { get; set; } // Password (not null)
        [StringLength(100)]
        public string? HoTen { get; set; } // FullName (nullable)
        [StringLength(100)]
        public string? Email { get; set; } // nullable
        [StringLength(100)]
        public string? AnhDaiDien { get; set; } // ImgName (nullable)
        [StringLength(20)]
        public string? SoDienThoai { get; set; } // nullable
        [StringLength(100)]
        public string? Token { get; set; } // nullable
        public DateTime? NgayHetHanToken { get; set; } // nullable
        public bool IsActive { get; set; } = true; // not null
        public ICollection<DiaChi>? DiaChis { get; set; } // nullable
        public ICollection<GioHang>? GioHangs { get; set; } // nullable
        public ICollection<HoaDon>? HoaDons { get; set; } // nullable
        public ICollection<LichSuHoaDon>? LichSuHoaDons { get; set; } // nullable
        public ICollection<VaiTroNguoiDung>VaiTroNguoiDungs { get; set; } // nullable
    }
} 