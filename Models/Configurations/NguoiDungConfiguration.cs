using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthDemo.Models;

namespace AuthDemo.Models.Configurations
{
    public class NguoiDungConfiguration : IEntityTypeConfiguration<NguoiDung>
    {
        public void Configure(EntityTypeBuilder<NguoiDung> builder)
        {
            builder.HasKey(x => x.UserID);
            builder.Property(x => x.TenDangNhap).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MatKhau).IsRequired().HasMaxLength(100);
            builder.Property(x => x.HoTen).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.AnhDaiDien).HasMaxLength(100);
            builder.Property(x => x.SoDienThoai).HasMaxLength(20);
            builder.Property(x => x.Token).HasMaxLength(100);
            builder.Property(x => x.NguoiTao).HasMaxLength(50);
            builder.Property(x => x.NguoiCapNhat).HasMaxLength(50);
            // Không còn HasOne<VaiTro>() và không seed RoleID ở đây
            builder.HasData(
                new NguoiDung {
                    UserID = new Guid("11111111-1111-1111-1111-111111111111"),
                    TenDangNhap = "admin",
                    MatKhau = "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=",
                    HoTen = "Quản trị viên",
                    Email = "admin@example.com",
                    SoDienThoai = "0123456789",
                    Token = "1234567890",
                    NgayHetHanToken = null,
                    IsActive = true,
                    AnhDaiDien = "admin.jpg",
                    
                    NguoiTao = "system",
                    NguoiCapNhat = "system"
                }
            );
        }
    }
}