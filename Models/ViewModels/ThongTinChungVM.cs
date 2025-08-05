using System;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models.ViewModels
{
    public abstract class ThongTinChungVM
    {
        [StringLength(50)]
        public string ?NguoiTao { get; set; }
        public DateTime ?NgayTao { get; set; }
        [StringLength(50)]
        public string ?NguoiCapNhat { get; set; }
        public DateTime? NgayCapNhat { get; set; }
    }
} 