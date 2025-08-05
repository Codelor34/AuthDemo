using System;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class DiaChi : ThongTinChung
    {
        [Key]
        public Guid AddressID { get; set; } // giữ nguyên
        [Required]
        public Guid UserID { get; set; } // giữ nguyên
        [StringLength(255)]
        public string DiaChiDayDu { get; set; }
        public NguoiDung NguoiDung { get; set; }
    }
} 