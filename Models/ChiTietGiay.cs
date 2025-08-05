using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AuthDemo.Models
{
    public class ChiTietGiay : ThongTinChung
    {
        [Key]
        public Guid ShoeDetailID { get; set; } // giữ nguyên
        [Required]
        public Guid ShoeID { get; set; } // giữ nguyên
        public Giay ?Giay { get; set; }
        [Required]
        public Guid CategoryID { get; set; } // giữ nguyên
        public DanhMuc ?DanhMuc { get; set; }
        [Required]
        public Guid SizeID { get; set; } // giữ nguyên
        public KichThuoc? KichThuoc { get; set; }
        [Required]
        public Guid ColorID { get; set; } // giữ nguyên
        public MauSac ?MauSac { get; set; }
        [Required]
        public Guid MaterialID { get; set; } // giữ nguyên
        public ChatLieu ?ChatLieu { get; set; }
        [Required]
        public Guid BrandID { get; set; } // giữ nguyên
        public ThuongHieu ?ThuongHieu { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
        public ICollection<AnhGiay>? AnhGiays { get; set; }
        public ICollection<ChiTietGioHang> ?ChiTietGioHangs { get; set; }
        public ICollection<ChiTietHoaDon> ?ChiTietHoaDons { get; set; }
    }
} 