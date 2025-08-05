using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthDemo.Models;

namespace AuthDemo.Models.Configurations
{
    public class DiaChiConfiguration : IEntityTypeConfiguration<DiaChi>
    {
        public void Configure(EntityTypeBuilder<DiaChi> builder)
        {
            builder.HasKey(x => x.AddressID);
            builder.Property(x => x.DiaChiDayDu).HasMaxLength(255);
            builder.Property(x => x.NguoiTao).HasMaxLength(50);
            builder.Property(x => x.NguoiCapNhat).HasMaxLength(50);
            builder.HasOne(x => x.NguoiDung)
                .WithMany(x => x.DiaChis)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DiaChi_NguoiDung");
            builder.HasData(
                new DiaChi {
                    AddressID = new Guid("44445555-6666-7777-8888-9999aaaabbbb"),
                    UserID = new Guid("11111111-1111-1111-1111-111111111111"),
                    DiaChiDayDu = "123 Đường ABC, Quận 1, TP.HCM" , NguoiTao = "system" , NguoiCapNhat = "system"
                }
            );
        }
    }
} 