using System;

namespace AuthDemo.Models.ViewModels
{
    public class UserWithRoleVM
    {
        public Guid UserID { get; set; }
        public string TenDangNhap { get; set; }
        public string? HoTen { get; set; }
        public string ?Email { get; set; }
        public string ?SoDienThoai { get; set; }
        public bool IsActive { get; set; }
        public string TenVaiTro { get; set; }
    }
} 