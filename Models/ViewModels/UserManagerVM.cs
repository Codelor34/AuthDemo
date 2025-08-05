using System;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models.ViewModels
{
    public class UserManagerVM : ThongTinChungVM
    {
        public Guid UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }

        public bool IsActive { get; set; } = true;

        public Guid? RoleID { get; set; } // Vai trò hiện tại
        public string? TenVaiTro { get; set; } // Tên vai trò (nếu cần hiển thị)
    }
}
