using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthDemo.Models;

namespace AuthDemo.Models.Configurations
{
    public class VaiTroNguoiDungConfiguration : IEntityTypeConfiguration<VaiTroNguoiDung>
    {
        public void Configure(EntityTypeBuilder<VaiTroNguoiDung> builder)
        {
            builder.HasKey(x => x.UserRoleID);
            builder.Property(x => x.UserRoleID).IsRequired();
            builder.Property(x => x.UserID).IsRequired();
            builder.Property(x => x.RoleID).IsRequired();

            builder.HasOne(x => x.NguoiDung)
                .WithMany(x => x.VaiTroNguoiDungs)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_VaiTroNguoiDung_NguoiDung");

            builder.HasOne(x => x.VaiTro)
                .WithMany(x => x.VaiTroNguoiDungs)
                .HasForeignKey(x => x.RoleID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_VaiTroNguoiDung_VaiTro");

            // Seed mẫu (nếu cần)
                builder.HasData(
                new VaiTroNguoiDung {
                    UserRoleID = new Guid("aaaa1111-1111-1111-1111-111111111111"),
                    UserID = new Guid("11111111-1111-1111-1111-111111111111"), // admin
                    RoleID = new Guid("11111111-1111-1111-1111-111111111111") // vai trò admin , NguoiTao = "system" , NguoiCapNhat = "system"
                }
                
            );
        }
    }
} 