using System.Collections.Generic;
using AuthDemo.Models.ViewModels;
using System;
using AuthDemo.Models;

namespace AuthDemo.Areas.Admin.Interface
{
    public interface IBanHangTaiQuayService
    {
        List<BanHangTaiQuayVM> SearchSanPham(string keyword);
        List<KhachHangDropdownVM> SearchKhachHang(string keyword);
        List<CartItemDisplayVM> GetCartItems(string tenDangNhap);
        void UpdateCart(string tenDangNhap, Guid shoeDetailId, string actionType);
        void UpdateDiscountCartItem(Guid cartDetailId, decimal? chietKhauPhanTram, decimal? chietKhauTienMat, bool? isTangKem, string reason);
    }
} 