using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthDemo.Models;

namespace AuthDemo.Models.Configurations
{
    public class GiayConfiguration : IEntityTypeConfiguration<Giay>
    {
        public void Configure(EntityTypeBuilder<Giay> builder)
        {
            builder.HasKey(x => x.ShoeID);
            builder.Property(x => x.TenGiay).IsRequired().HasMaxLength(100);
            builder.Property(x => x.MaGiayCode).HasMaxLength(50);
            builder.Property(x => x.MoTa).HasMaxLength(255);
            builder.Property(x => x.TrangThai).HasMaxLength(50);
            builder.Property(x => x.NguoiTao).HasMaxLength(50);
            builder.Property(x => x.NguoiCapNhat).HasMaxLength(50);
            builder.HasData(
                new Giay { ShoeID = new Guid("99999999-9999-9999-9999-999999999999"), TenGiay = "Air Max", MaGiayCode = "AMX", MoTa = "Giày thể thao Nike", TrangThai = "Còn hàng" , NguoiTao = "system" , NguoiCapNhat = "system"},
                new Giay { ShoeID = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), TenGiay = "Ultraboost", MaGiayCode = "UBS", MoTa = "Giày thể thao Adidas", TrangThai = "Còn hàng" , NguoiTao = "system" , NguoiCapNhat = "system"}
            );
        }
    }
} 