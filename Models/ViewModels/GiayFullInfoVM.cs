using System;
using System.Collections.Generic;
using AuthDemo.Models;

namespace AuthDemo.Models.ViewModels
{
    public class GiayFullInfoVM
    {
        public Giay Giay { get; set; }
        public string TenDanhMuc { get; set; }
        public string MaGiayCode { get; set; }
        public string MoTa { get; set; }
        public string TenKichThuoc { get; set; }
        public string TenMau { get; set; }
        public string TenKichCo { get; set; }
        public string TenDanhMucPhu { get; set; }
        public string TenThuongHieu { get; set; }
        public string TenChatLieu { get; set; }
        public IEnumerable<ChiTietGiay> ChiTietGiays { get; set; }
        public int TongSoLuong { get; set; }
    }
} 