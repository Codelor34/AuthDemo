using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models.Enums
{
    public enum PhuongThucVanChuyen
    {
        [Display(Name = "Giao hàng nhanh")]
        GiaoHangNhanh = 0,
        [Display(Name = "Giao hàng tiết kiệm")]
        GiaoHangTietKiem = 1,
        [Display(Name = "Tự đến lấy")]
        TuDenLay = 2
    }
} 