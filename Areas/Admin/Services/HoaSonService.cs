using AuthDemo.Areas.Admin.Interface;
using AuthDemo.Data;
using AuthDemo.Models.ViewModels;
using AuthDemo.Models.Enums;
using AuthDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthDemo.Areas.Admin.Services
{
    public class HoaDonService : IHoaDonService
    {
        private readonly ApplicationDbContext _db;
        public HoaDonService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<GetAllHoaDonVM> GetAllHoaDon()
        {
            var hoaDons = _db.HoaDons.Select(x => new GetAllHoaDonVM
            {
                HoaDonID = x.BillID,
                UserID = x.UserID,
                TongTien = x.TongTien,
                NguoiTao = x.NguoiTao ?? "",
                NgayTao = x.NgayTao,
                NguoiCapNhat = x.NguoiCapNhat ?? "",
                NgayCapNhat = x.NgayCapNhat,
                TenKhachHang = x.NguoiDung.HoTen,
                SoDienThoai = x.NguoiDung.SoDienThoai,
                Email = x.NguoiDung.Email,
                DiaChi = x.NguoiDung != null && x.NguoiDung.DiaChis != null && x.NguoiDung.DiaChis.Any()
                    ? x.NguoiDung.DiaChis.Select(d => d.DiaChiDayDu).FirstOrDefault()
                    : "",
                HinhThucThanhToan = x.PhuongThucThanhToan,
                TrangThai = x.TrangThai,
                HinhThucVanChuyen = x.PhuongThucVanChuyen,
                TrangThaiDisplay = x.TrangThai.GetDisplayName(),
                HinhThucThanhToanDisplay = x.PhuongThucThanhToan.GetDisplayName(),
                HinhThucVanChuyenDisplay = x.PhuongThucVanChuyen.GetDisplayName(),
            }).ToList();
            return hoaDons;
        }
        public GetAllHoaDonVM? GetHoaDonByID(Guid id)
        {
            var x = _db.HoaDons
       .Include(h => h.ChiTietHoaDons)
       .Include(h => h.NguoiDung)
           .ThenInclude(nd => nd.DiaChis)
       .FirstOrDefault(h => h.BillID == id);

            if (x == null) return null;

            return new GetAllHoaDonVM
            {
                HoaDonID = x.BillID,
                UserID = x.UserID,
                TongTien = x.TongTien,
                NguoiTao = x.NguoiTao ?? "",
                NgayTao = x.NgayTao,
                NguoiCapNhat = x.NguoiCapNhat ?? "",
                NgayCapNhat = x.NgayCapNhat,
                TenKhachHang = x.NguoiDung?.HoTen,
                SoDienThoai = x.NguoiDung?.SoDienThoai,
                Email = x.NguoiDung?.Email,
                DiaChi = x.NguoiDung != null && x.NguoiDung.DiaChis != null && x.NguoiDung.DiaChis.Any()
                    ? x.NguoiDung.DiaChis.Select(d => d.DiaChiDayDu).FirstOrDefault()
                    : "",
                HinhThucThanhToan = x.PhuongThucThanhToan,
                TrangThai = x.TrangThai,
                HinhThucVanChuyen = x.PhuongThucVanChuyen,
                TrangThaiDisplay = x.TrangThai.GetDisplayName(),
                HinhThucThanhToanDisplay = x.PhuongThucThanhToan.GetDisplayName(),
                HinhThucVanChuyenDisplay = x.PhuongThucVanChuyen.GetDisplayName(),
            };
        }

    }
}