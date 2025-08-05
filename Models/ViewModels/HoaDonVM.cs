using AuthDemo.Models.Enums;

namespace AuthDemo.Models.ViewModels
{
    public class GetAllHoaDonVM
    {
        public Guid HoaDonID { get; set; }
        public Guid UserID { get; set; }
        public TrangThaiHoaDon TrangThai { get; set; }
        public decimal TongTien { get; set; }
        public string ?NguoiTao { get; set; }
        public DateTime ?NgayTao { get; set; }
        public string ?NguoiCapNhat { get; set; }
        public DateTime ?NgayCapNhat { get; set; }
        public string ?TenKhachHang { get; set; }
        public string ?SoDienThoai { get; set; }
        public string ?Email { get; set; }
        public string ?DiaChi { get; set; }
        public PhuongThucThanhToan HinhThucThanhToan { get; set; }
        public PhuongThucVanChuyen HinhThucVanChuyen { get; set; }
        // Thêm các trường display
        public string TrangThaiDisplay { get; set; }
        public string HinhThucThanhToanDisplay { get; set; }
        public string HinhThucVanChuyenDisplay { get; set; }
    }
}