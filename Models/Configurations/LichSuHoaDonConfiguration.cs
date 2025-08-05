using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthDemo.Models;

namespace AuthDemo.Models.Configurations
{
    public class LichSuHoaDonConfiguration : IEntityTypeConfiguration<LichSuHoaDon>
    {
        public void Configure(EntityTypeBuilder<LichSuHoaDon> builder)
        {
            builder.HasKey(x => x.BillHistoryID);
            builder.Property(x => x.BillCode).HasMaxLength(50);
            builder.Property(x => x.HoTen).HasMaxLength(100);
            builder.Property(x => x.DiaChiCu).HasMaxLength(255);
            builder.Property(x => x.DiaChiMoi).HasMaxLength(255);
            builder.Property(x => x.TrangThaiCu).HasMaxLength(50);
            builder.Property(x => x.TrangThaiMoi).HasMaxLength(50);
            builder.Property(x => x.GhiChu).HasMaxLength(255);
            builder.Property(x => x.NguoiTao).HasMaxLength(50);
            builder.Property(x => x.NguoiCapNhat).HasMaxLength(50);
            builder.HasOne(x => x.HoaDon)
                .WithMany(x => x.LichSuHoaDons)
                .HasForeignKey(x => x.BillID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_LichSuHoaDon_HoaDon");
            builder.HasOne(x => x.NguoiDung)
                .WithMany(x => x.LichSuHoaDons)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_LichSuHoaDon_NguoiDung");
            builder.HasData(
                new LichSuHoaDon {
                    BillHistoryID = new Guid("33334444-5555-6666-7777-88889999aaaa"),
                    BillID = new Guid("11112222-3333-4444-5555-666677778888"),
                    BillCode = "HD001",
                    UserID = new Guid("11111111-1111-1111-1111-111111111111"),
                    HoTen = "Nguyễn Văn A",
                    DiaChiCu = "Hà Nội",
                    DiaChiMoi = "Hồ Chí Minh",
                    TrangThaiCu = "Chờ xác nhận",
                    TrangThaiMoi = "Đã thanh toán",
                    GhiChu = "Chuyển địa chỉ giao hàng",
                    NguoiTao = "system",
                    NguoiCapNhat = "system"
                }
            );
        }
    }
} 