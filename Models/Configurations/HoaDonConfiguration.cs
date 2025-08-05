using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthDemo.Models;
using AuthDemo.Models.Enums;

namespace AuthDemo.Models.Configurations
{
    public class HoaDonConfiguration : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.HasKey(x => x.BillID);
            builder.Property(x => x.HoTen).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.SoDienThoai).HasMaxLength(20);
            builder.Property(x => x.DiaChi).HasMaxLength(255);
            builder.Property(x => x.TrangThai).HasMaxLength(50);
            builder.Property(x => x.PhuongThucThanhToan).HasMaxLength(50);
            builder.Property(x => x.GhiChu).HasMaxLength(255);
            builder.Property(x => x.LyDo).HasMaxLength(255);
            builder.Property(x => x.NguoiTao).HasMaxLength(50);
            builder.Property(x => x.NguoiCapNhat).HasMaxLength(50);
            builder.HasOne(x => x.NguoiDung)
                .WithMany(x => x.HoaDons)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_HoaDon_NguoiDung");
            builder.HasData(
                new HoaDon {
                    BillID = new Guid("11112222-3333-4444-5555-666677778888"),
                    UserID = new Guid("11111111-1111-1111-1111-111111111111"),
                    HoTen = "Nguyễn Văn A",
                    Email = "admin@example.com",
                    SoDienThoai = "0123456789",
                    DiaChi = "Hà Nội",
                    TongTien = 5000000,
                    TrangThai = TrangThaiHoaDon.DaThanhToan,
                    DaThanhToan = true,
                    PhuongThucThanhToan = PhuongThucThanhToan.TienMat,
                    DaHuy = false,
                    GhiChu = "",
                    LyDo = "",
                    NgayGiaoHang = null,
                    NguoiTao = "system",
                    NguoiCapNhat = "system"
                }
            );
        }
    }
} 