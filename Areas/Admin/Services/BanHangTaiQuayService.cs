using System;
using System.Collections.Generic;
using System.Linq;
using AuthDemo.Data;
using AuthDemo.Models.ViewModels;
using AuthDemo.Areas.Admin.Interface;
using Microsoft.EntityFrameworkCore;
using AuthDemo.Models;

namespace AuthDemo.Areas.Admin.Services
{
    public class BanHangTaiQuayService : IBanHangTaiQuayService
    {
        private readonly ApplicationDbContext _db;
        public BanHangTaiQuayService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<BanHangTaiQuayVM> SearchSanPham(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return _db.ChiTietGiays.Select(sp => new BanHangTaiQuayVM {
                    ShoeDetailID = sp.ShoeDetailID,
                    TenSp = sp.Giay != null ? sp.Giay.TenGiay : "Chưa có",
                    Gia = sp.Gia,
                    SoLuong = sp.SoLuong,
                    MauSac = sp.MauSac != null ? sp.MauSac.TenMau : "Chưa có",
                    KichThuoc = sp.KichThuoc != null ? sp.KichThuoc.TenKichThuoc : "Chưa có",
                    ChatLieu = sp.ChatLieu != null ? sp.ChatLieu.TenChatLieu : "Chưa có",
                    ThuongHieu = sp.ThuongHieu != null ? sp.ThuongHieu.TenThuongHieu : "Chưa có",
                    DanhMuc = sp.DanhMuc != null ? sp.DanhMuc.TenDanhMuc : "Chưa có",
                    Giay = sp.Giay != null ? sp.Giay.TenGiay : "Chưa có"
                }).Take(20).ToList();
            }
            var lowerKeyword = keyword.ToLower();
            return _db.ChiTietGiays
                .Where(sp => sp.Giay != null && sp.Giay.TenGiay.ToLower().Contains(lowerKeyword))
                .Select(sp => new BanHangTaiQuayVM {
                    ShoeDetailID = sp.ShoeDetailID,
                    TenSp = sp.Giay != null ? sp.Giay.TenGiay : "Chưa có",
                    Gia = sp.Gia,
                    SoLuong = sp.SoLuong,
                    MauSac = sp.MauSac != null ? sp.MauSac.TenMau : "Chưa có",
                    KichThuoc = sp.KichThuoc != null ? sp.KichThuoc.TenKichThuoc : "Chưa có",
                    ChatLieu = sp.ChatLieu != null ? sp.ChatLieu.TenChatLieu : "Chưa có",
                    ThuongHieu = sp.ThuongHieu != null ? sp.ThuongHieu.TenThuongHieu : "Chưa có",
                    DanhMuc = sp.DanhMuc != null ? sp.DanhMuc.TenDanhMuc : "Chưa có",
                    Giay = sp.Giay != null ? sp.Giay.TenGiay : "Chưa có"
                })
                .Take(20)
                .ToList();
        }
        public List<KhachHangDropdownVM> SearchKhachHang(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<KhachHangDropdownVM>();

            var lowerKeyword = keyword.ToLower();
            var users = _db.NguoiDungs
                .Where(u => u.IsActive
                    && u.VaiTroNguoiDungs != null
                    && u.VaiTroNguoiDungs.Count > 0
                    && u.VaiTroNguoiDungs.Any(r => r.VaiTro.TenVaiTro == "user")
                    && (
                        (u.TenDangNhap != null && u.TenDangNhap.ToLower().Contains(lowerKeyword))
                        || (u.SoDienThoai != null && u.SoDienThoai.ToLower().Contains(lowerKeyword))
                        || (u.Email != null && u.Email.ToLower().Contains(lowerKeyword))
                        || (u.HoTen != null && u.HoTen.ToLower().Contains(lowerKeyword))
                    )
                )
                .Select(u => new {
                    u.UserID,
                    u.TenDangNhap,
                    u.HoTen,
                    u.SoDienThoai,
                    u.Email,
                    TenVaiTro = u.VaiTroNguoiDungs.Select(r => r.VaiTro.TenVaiTro).FirstOrDefault() ?? "",
                    DiaChiObj = (u.DiaChis != null && u.DiaChis.Any()) ? u.DiaChis.FirstOrDefault() : null
                })
                .AsEnumerable() // chuyển sang LINQ to Objects để dùng null-safe
                .Select(u => new KhachHangDropdownVM {
                    UserID = u.UserID,
                    TenDangNhap = u.TenDangNhap,
                    HoTen = u.HoTen,
                    SoDienThoai = u.SoDienThoai,
                    Email = u.Email,
                    TenVaiTro = u.TenVaiTro,
                    // Đảm bảo không dereference null, không dùng ?. trong LINQ to Entities
                    DiaChi = u.DiaChiObj != null ? u.DiaChiObj.DiaChiDayDu : ""
                })
                .Take(10)
                .ToList();

            return users;
        }

        public List<CartItemDisplayVM> GetCartItems(string tenDangNhap)
        {
            if (string.IsNullOrEmpty(tenDangNhap)) return new List<CartItemDisplayVM>();
            var user = _db.NguoiDungs.FirstOrDefault(u => u.TenDangNhap == tenDangNhap);
            if (user == null) return new List<CartItemDisplayVM>();
            var cart = _db.GioHangs.FirstOrDefault(g => g.UserID == user.UserID);
            if (cart == null) return new List<CartItemDisplayVM>();
            var cartItems = _db.ChiTietGioHangs
                .Where(c => c.CartID == cart.CartID)
                .Include(c => c.ChiTietGiay)
                .ThenInclude(g => g.Giay)
                .Include(c => c.ChiTietGiay.MauSac)
                .Include(c => c.ChiTietGiay.KichThuoc)
                .Include(c => c.ChiTietGiay.ChatLieu)
                .Include(c => c.ChiTietGiay.ThuongHieu)
                .Include(c => c.ChiTietGiay.DanhMuc)
                .ToList();
            var result = cartItems.Select(item => {
                var ctg = item.ChiTietGiay;
                var giaGoc = (ctg?.Gia ?? 0) * item.SoLuong;
                var ckpt = item.ChietKhauPhanTram ?? 0;
                var cktm = item.ChietKhauTienMat ?? 0;
                var isTang = item.IsTangKem == true;
                var giaSauGiam = isTang ? 0 : Math.Max(0, giaGoc - (giaGoc * ckpt / 100) - cktm);
                return new CartItemDisplayVM {
                    CartDetailID = item.CartDetailID,
                    ShoeDetailID = item.ShoeDetailID,
                    TenSanPham = ctg?.Giay?.TenGiay ?? "",
                    MauSac = ctg?.MauSac?.TenMau,
                    KichThuoc = ctg?.KichThuoc?.TenKichThuoc,
                    SoLuong = item.SoLuong,
                    GiaGoc = giaGoc,
                    GiaSauGiam = giaSauGiam,
                    IsTangKem = isTang,
                    ChietKhauPhanTram = item.ChietKhauPhanTram,
                    ChietKhauTienMat = item.ChietKhauTienMat,
                    ThuongHieu = ctg?.ThuongHieu?.TenThuongHieu,
                    ChatLieu = ctg?.ChatLieu?.TenChatLieu,
                    DanhMuc = ctg?.DanhMuc?.TenDanhMuc,
                    LyDo = item.LyDo
                };
            }).ToList();
            return result;
        }

        public void UpdateCart(string tenDangNhap, Guid shoeDetailId, string actionType)
        {
            var user = _db.NguoiDungs.FirstOrDefault(u => u.TenDangNhap == tenDangNhap);
            if (user == null) return;
            var cart = _db.GioHangs.FirstOrDefault(g => g.UserID == user.UserID);
            if (cart == null)
            {
                cart = new GioHang { CartID = Guid.NewGuid(), UserID = user.UserID };
                _db.GioHangs.Add(cart);
                _db.SaveChanges();
            }
            var cartItem = _db.ChiTietGioHangs.FirstOrDefault(c => c.CartID == cart.CartID && c.ShoeDetailID == shoeDetailId);
            if (actionType == "add" || actionType == "increase")
            {
                if (cartItem == null)
                {
                    var chiTietGiay = _db.ChiTietGiays
                        .Include(ctg => ctg.KichThuoc)
                        .FirstOrDefault(ctg => ctg.ShoeDetailID == shoeDetailId);
                    string tenKichThuoc = chiTietGiay?.KichThuoc?.TenKichThuoc ?? "";
                    cartItem = new ChiTietGioHang
                    {
                        CartDetailID = Guid.NewGuid(),
                        CartID = cart.CartID,
                        ShoeDetailID = shoeDetailId,
                        KichThuoc = tenKichThuoc,
                        SoLuong = 1
                    };
                    _db.ChiTietGioHangs.Add(cartItem);
                }
                else
                {
                    cartItem.SoLuong += 1;
                    _db.ChiTietGioHangs.Update(cartItem);
                }
            }
            else if (actionType == "decrease" && cartItem != null)
            {
                cartItem.SoLuong -= 1;
                if (cartItem.SoLuong <= 0)
                    _db.ChiTietGioHangs.Remove(cartItem);
                else
                    _db.ChiTietGioHangs.Update(cartItem);
            }
            else if (actionType == "remove" && cartItem != null)
            {
                _db.ChiTietGioHangs.Remove(cartItem);
            }
            _db.SaveChanges();
        }

        public void UpdateDiscountCartItem(Guid cartDetailId, decimal? chietKhauPhanTram, decimal? chietKhauTienMat, bool? isTangKem, string reason)
        {
            var cartItem = _db.ChiTietGioHangs.FirstOrDefault(x => x.CartDetailID == cartDetailId);
            if (cartItem == null) return;
            cartItem.ChietKhauPhanTram = chietKhauPhanTram;
            cartItem.ChietKhauTienMat = chietKhauTienMat;
            cartItem.IsTangKem = isTangKem;
            cartItem.LyDo = reason;
            _db.ChiTietGioHangs.Update(cartItem);
            _db.SaveChanges();
        }
    }
} 