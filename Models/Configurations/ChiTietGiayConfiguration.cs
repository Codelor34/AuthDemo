using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthDemo.Models;
using System;

namespace AuthDemo.Models.Configurations
{
    public class ChiTietGiayConfiguration : IEntityTypeConfiguration<ChiTietGiay>
    {
        public void Configure(EntityTypeBuilder<ChiTietGiay> builder)
        {
            builder.HasKey(x => x.ShoeDetailID);

            builder.Property(x => x.SoLuong).IsRequired();
            builder.Property(x => x.Gia).IsRequired();
            builder.Property(x => x.NguoiTao).HasMaxLength(50);
            builder.Property(x => x.NguoiCapNhat).HasMaxLength(50);

            builder.HasOne(x => x.Giay)
                .WithMany(x => x.ChiTietGiays)
                .HasForeignKey(x => x.ShoeID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ChiTietGiay_Giay");
            builder.HasOne(x => x.DanhMuc)
                .WithMany(x => x.ChiTietGiays)
                .HasForeignKey(x => x.CategoryID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ChiTietGiay_DanhMuc");
            builder.HasOne(x => x.KichThuoc)
                .WithMany(x => x.ChiTietGiays)
                .HasForeignKey(x => x.SizeID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ChiTietGiay_KichThuoc");
            builder.HasOne(x => x.MauSac)
                .WithMany(x => x.ChiTietGiays)
                .HasForeignKey(x => x.ColorID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ChiTietGiay_MauSac");
            builder.HasOne(x => x.ChatLieu)
                .WithMany(x => x.ChiTietGiays)
                .HasForeignKey(x => x.MaterialID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ChiTietGiay_ChatLieu");
            builder.HasOne(x => x.ThuongHieu)
                .WithMany(x => x.ChiTietGiays)
                .HasForeignKey(x => x.BrandID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ChiTietGiay_ThuongHieu");

            builder.HasData(
                new ChiTietGiay
                {
                    ShoeDetailID = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    ShoeID = new Guid("99999999-9999-9999-9999-999999999999"),
                    CategoryID = new Guid("77777777-7777-7777-7777-777777777777"),
                    SizeID = new Guid("33333333-3333-3333-3333-333333333333"),
                    ColorID = new Guid("11111111-1111-1111-1111-111111111111"),
                    MaterialID = new Guid("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                    BrandID = new Guid("55555555-5555-5555-5555-555555555555"),
                    SoLuong = 10,
                    Gia = 2500000,
                    NguoiTao = "system",
                    NguoiCapNhat = "system"
                }
            );
        }
    }
}
