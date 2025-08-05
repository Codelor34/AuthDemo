using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AuthDemo.Models.Enums
{
    public enum TrangThaiHoaDon
    {
        [Display(Name = "Chờ xác nhận")]
        ChoXacNhan = 0,

        [Display(Name = "Đã xác nhận")]
        DaXacNhan = 1,

        [Display(Name = "Đang giao hàng")]
        DangGiaoHang = 2,

        [Display(Name = "Đã giao")]
        DaGiao = 3,

        [Display(Name = "Đã hủy")]
        DaHuy = 4,

        [Display(Name = "Đã thanh toán")]
        DaThanhToan = 5
    }

    
}
