using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthDemo.Models;

namespace AuthDemo.Models.Configurations
{
    public class DanhMucConfiguration : IEntityTypeConfiguration<DanhMuc>
    {
        public void Configure(EntityTypeBuilder<DanhMuc> builder)
        {
            builder.HasKey(x => x.CategoryID);
            builder.Property(x => x.TenDanhMuc).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MaDanhMucCode).HasMaxLength(50);
            builder.Property(x => x.MoTa).HasMaxLength(255);
            builder.Property(x => x.NguoiTao).HasMaxLength(50);
            builder.Property(x => x.NguoiCapNhat).HasMaxLength(50);
            builder.HasData(
                new DanhMuc { CategoryID = new Guid("77777777-7777-7777-7777-777777777777"), TenDanhMuc = "Thể thao", MaDanhMucCode = "SPORT", MoTa = "Sản phẩm thể thao" , NguoiTao = "system" , NguoiCapNhat = "system"},
                new DanhMuc { CategoryID = new Guid("88888888-8888-8888-8888-888888888888"), TenDanhMuc = "Thời trang", MaDanhMucCode = "FASHION", MoTa = "Sản phẩm thời trang" , NguoiTao = "system" , NguoiCapNhat = "system"}
            );
        }
    }
} 