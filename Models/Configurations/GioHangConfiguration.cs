using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthDemo.Models;

namespace AuthDemo.Models.Configurations
{
    public class GioHangConfiguration : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.HasKey(x => x.CartID);
            builder.Property(x => x.NguoiTao).HasMaxLength(50);
            builder.Property(x => x.NguoiCapNhat).HasMaxLength(50);
            builder.HasOne(x => x.NguoiDung)
                .WithMany(x => x.GioHangs)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_GioHang_NguoiDung");
            builder.HasData(
                new GioHang { CartID = new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), UserID = new Guid("11111111-1111-1111-1111-111111111111") , NguoiTao = "system" , NguoiCapNhat = "system"  }
            );
        }
    }
} 