using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthDemo.Models;

namespace AuthDemo.Models.Configurations
{
    public class VaiTroConfiguration : IEntityTypeConfiguration<VaiTro>
    {
        public void Configure(EntityTypeBuilder<VaiTro> builder)
        {
            builder.HasKey(x => x.RoleID);
            builder.Property(x => x.TenVaiTro).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MoTa).HasMaxLength(255);
            builder.Property(x => x.NguoiTao).HasMaxLength(50);
            builder.Property(x => x.NguoiCapNhat).HasMaxLength(50);
            builder.HasData(
                new VaiTro { RoleID = new Guid("11111111-1111-1111-1111-111111111111"), TenVaiTro = "admin", MoTa = "Quản trị viên" , NguoiTao = "system" , NguoiCapNhat = "system"},
                new VaiTro { RoleID = new Guid("22222222-2222-2222-2222-222222222222"), TenVaiTro = "user", MoTa = "Người dùng thường" , NguoiTao = "system" , NguoiCapNhat = "system"}
            );
        }
    }
} 