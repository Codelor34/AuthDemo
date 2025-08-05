using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthDemo.Models;

namespace AuthDemo.Models.Configurations
{
    public class ThuongHieuConfiguration : IEntityTypeConfiguration<ThuongHieu>
    {
        public void Configure(EntityTypeBuilder<ThuongHieu> builder)
        {
            builder.HasKey(x => x.BrandID);
            builder.Property(x => x.TenThuongHieu).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MaThuongHieuCode).HasMaxLength(50);
            builder.Property(x => x.NguoiTao).HasMaxLength(50);
            builder.Property(x => x.NguoiCapNhat).HasMaxLength(50);
            builder.HasData(
                new ThuongHieu { BrandID = new Guid("55555555-5555-5555-5555-555555555555"), TenThuongHieu = "Nike", MaThuongHieuCode = "NIKE" , NguoiTao = "system" , NguoiCapNhat = "system"},
                new ThuongHieu { BrandID = new Guid("66666666-6666-6666-6666-666666666666"), TenThuongHieu = "Adidas", MaThuongHieuCode = "ADIDAS" , NguoiTao = "system" , NguoiCapNhat = "system"}
            );
        }
    }
} 