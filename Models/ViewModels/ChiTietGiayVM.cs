using System;

namespace AuthDemo.Models.ViewModels
{
    public class ChiTietGiayVM
    {
        // ViewModel cho Index
        public class IndexVM
        {
            public Guid ShoeDetailID { get; set; }
            public string? TenGiay { get; set; }
            public string? TenKichThuoc { get; set; }
            public string? TenMau { get; set; }
            public string? TenChatLieu { get; set; }
            public string? TenThuongHieu { get; set; }
            public string? TenDanhMuc { get; set; }
            public int SoLuong { get; set; }
            public decimal Gia { get; set; }
        }

        // ViewModel cho Create
        public class CreateVM
        {
            public Guid ShoeID { get; set; }
            public Guid SizeID { get; set; }
            public Guid ColorID { get; set; }
            public Guid MaterialID { get; set; }
            public Guid BrandID { get; set; }
            public Guid CategoryID { get; set; }
            public int SoLuong { get; set; }
            public decimal Gia { get; set; }
        }

        // ViewModel cho Edit
        public class EditVM
        {
            public Guid ShoeDetailID { get; set; }
            public Guid ShoeID { get; set; }
            public Guid SizeID { get; set; }
            public Guid ColorID { get; set; }
            public Guid MaterialID { get; set; }
            public Guid BrandID { get; set; }
            public Guid CategoryID { get; set; }
            public int SoLuong { get; set; }
            public decimal Gia { get; set; }
        }
    }
} 