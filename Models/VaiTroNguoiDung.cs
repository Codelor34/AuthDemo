using System;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class VaiTroNguoiDung
    {
        [Key]
        public Guid UserRoleID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        [Required]
        public Guid RoleID { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public VaiTro VaiTro { get; set; }
    }
} 