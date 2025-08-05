using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthDemo.Models;

namespace AuthDemo.Models.Configurations
{
    public class MauSacConfiguration : IEntityTypeConfiguration<MauSac>
    {
        public void Configure(EntityTypeBuilder<MauSac> builder)
        {
            builder.HasKey(x => x.ColorID);
            builder.Property(x => x.TenMau).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MaMau).HasMaxLength(50);
            builder.Property(x => x.NguoiTao).HasMaxLength(50);
            builder.Property(x => x.NguoiCapNhat).HasMaxLength(50);
            builder.HasData(
                new MauSac { ColorID = new Guid("11111111-1111-1111-1111-111111111111"), TenMau = "Đỏ", MaMau = "RED" , NguoiTao = "system" , NguoiCapNhat = "system"},
                new MauSac { ColorID = new Guid("22222222-2222-2222-2222-222222222222"), TenMau = "Xanh", MaMau = "BLUE" , NguoiTao = "system" , NguoiCapNhat = "system"}
            );
        }
    }
} 