using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models.ViewModels
{
    public class GiayVM
    {
        public Guid ShoeID { get; set; }

        [StringLength(100)]
        public string TenGiay { get; set; }

        [StringLength(50)]
        public string MaGiayCode { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        // Thông tin cập nhật
        [StringLength(50)]
        public string ?NguoiCapNhat { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        // // Danh sách chi tiết giày (nếu cần)
        // public List<ChiTietGiay> ChiTietGiays { get; set; } = new List<ChiTietGiay>();
    }
}
