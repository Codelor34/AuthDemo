using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthDemo.Models;

namespace AuthDemo.Models.Configurations
{
    public class ChiTietHoaDonConfiguration : IEntityTypeConfiguration<ChiTietHoaDon>
    {
        public void Configure(EntityTypeBuilder<ChiTietHoaDon> builder)
        {
            builder.HasKey(x => x.BillDetailID);
            builder.Property(x => x.SoLuong).IsRequired();
            builder.Property(x => x.DonGia).IsRequired();
            builder.Property(x => x.NguoiTao).HasMaxLength(50);
            builder.Property(x => x.NguoiCapNhat).HasMaxLength(50);
            builder.HasOne(x => x.HoaDon)
                .WithMany(x => x.ChiTietHoaDons)
                .HasForeignKey(x => x.BillID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ChiTietHoaDon_HoaDon");
            builder.HasOne(x => x.ChiTietGiay)
                .WithMany(x => x.ChiTietHoaDons)
                .HasForeignKey(x => x.ShoeDetailID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ChiTietHoaDon_ChiTietGiay");
            builder.HasData(
                new ChiTietHoaDon {
                    BillDetailID = new Guid("22223333-4444-5555-6666-777788889999"),
                    BillID = new Guid("11112222-3333-4444-5555-666677778888"),
                    ShoeDetailID = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    SoLuong = 1, DonGia = 2500000, NguoiTao = "system" , NguoiCapNhat = "system"
                }
            );
        }
    }
} 