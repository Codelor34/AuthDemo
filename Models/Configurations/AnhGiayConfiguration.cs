using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthDemo.Models;
using System;

namespace AuthDemo.Models.Configurations
{
    public class AnhGiayConfiguration : IEntityTypeConfiguration<AnhGiay>
    {
        public void Configure(EntityTypeBuilder<AnhGiay> builder)
        {
            builder.HasKey(x => x.ImageShoeID);

            builder.Property(x => x.DuongDanAnh).HasMaxLength(255);
            builder.Property(x => x.NguoiTao).HasMaxLength(50);
            builder.Property(x => x.NguoiCapNhat).HasMaxLength(50);

            builder.HasOne(x => x.ChiTietGiay) // navigation property
                   .WithMany(x => x.AnhGiays)
                   .HasForeignKey(x => x.ShoeDetailID)
                   .HasConstraintName("FK_AnhGiay_ChiTietGiay")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new AnhGiay
                {
                    ImageShoeID = new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                    ShoeDetailID = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    DuongDanAnh = "/images/airmax1.jpg",
                    NguoiTao = "system",
                    NguoiCapNhat = "system"
                },
                new AnhGiay
                {
                    ImageShoeID = new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                    ShoeDetailID = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    DuongDanAnh = "/images/airmax2.jpg",
                    NguoiTao = "system",
                    NguoiCapNhat = "system"
                }
            );
        }
    }
}
