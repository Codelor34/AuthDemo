using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthDemo.Models;

namespace AuthDemo.Models.Configurations
{
    public class KichThuocConfiguration : IEntityTypeConfiguration<KichThuoc>
    {
        public void Configure(EntityTypeBuilder<KichThuoc> builder)
        {
            builder.HasKey(x => x.SizeID);
            builder.Property(x => x.TenKichThuoc).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MaKichThuocCode).HasMaxLength(50);
            builder.Property(x => x.NguoiTao).HasMaxLength(50);
            builder.Property(x => x.NguoiCapNhat).HasMaxLength(50);
            builder.HasData(
                new KichThuoc { SizeID = new Guid("33333333-3333-3333-3333-333333333333"), TenKichThuoc = "S", MaKichThuocCode = "S" , NguoiTao = "system" , NguoiCapNhat = "system"},
                new KichThuoc { SizeID = new Guid("44444444-4444-4444-4444-444444444444"), TenKichThuoc = "M", MaKichThuocCode = "M" , NguoiTao = "system" , NguoiCapNhat = "system"}
            );
        }
    }
} 