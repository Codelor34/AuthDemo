using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthDemo.Models;

namespace AuthDemo.Models.Configurations
{
    public class ChiTietGioHangConfiguration : IEntityTypeConfiguration<ChiTietGioHang>
    {
        public void Configure(EntityTypeBuilder<ChiTietGioHang> builder)
        {
            builder.HasKey(x => x.CartDetailID);
            builder.Property(x => x.KichThuoc).HasMaxLength(50);
            builder.Property(x => x.NguoiTao).HasMaxLength(50);
            builder.Property(x => x.NguoiCapNhat).HasMaxLength(50);
            builder.HasOne(x => x.GioHang)
                .WithMany(x => x.ChiTietGioHangs)
                .HasForeignKey(x => x.CartID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ChiTietGioHang_GioHang");
            builder.HasOne(x => x.ChiTietGiay)
                .WithMany(x => x.ChiTietGioHangs)
                .HasForeignKey(x => x.ShoeDetailID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ChiTietGioHang_ChiTietGiay");
            builder.HasData(
                new ChiTietGioHang { CartDetailID = new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), CartID = new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), ShoeDetailID = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), SoLuong = 2, KichThuoc = "M" , NguoiTao = "system" , NguoiCapNhat = "system"}
            );
        }
    }
} 