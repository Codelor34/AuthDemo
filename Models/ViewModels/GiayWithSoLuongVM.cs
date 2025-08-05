using System;
using AuthDemo.Models;

namespace AuthDemo.Models.ViewModels
{
    public class GiayWithSoLuongVM
    {
        public Giay Giay { get; set; }
        public int TongSoLuong { get; set; }

         public string ?NguoiCapNhat { get; set; }

        public DateTime? NgayCapNhat { get; set; }

         public string ?NguoiTao { get; set; }

        public DateTime? NgayTao { get; set; }
    }
} 