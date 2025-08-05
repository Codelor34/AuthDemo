using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthDemo.Models;
using System;

namespace AuthDemo.Models.Configurations
{
    public class ChatLieuConfiguration : IEntityTypeConfiguration<ChatLieu>
    {
        public void Configure(EntityTypeBuilder<ChatLieu> builder)
        {
            builder.HasKey(x => x.MaterialID);
            builder.Property(x => x.TenChatLieu).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MaChatLieuCode).HasMaxLength(50);
            builder.Property(x => x.NguoiTao).HasMaxLength(50);
            builder.Property(x => x.NguoiCapNhat).HasMaxLength(50);

            // Seed dữ liệu mẫu
            builder.HasData(
                new ChatLieu { MaterialID = new Guid("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), TenChatLieu = "Cotton", MaChatLieuCode = "CTN" , NguoiTao = "system" , NguoiCapNhat = "system"},
                new ChatLieu { MaterialID = new Guid("8a9b0c1d-2e3f-4a5b-6c7d-8e9f0a1b2c3d"), TenChatLieu = "Len", MaChatLieuCode = "LEN" , NguoiTao = "system" , NguoiCapNhat = "system"}
            );
        }
    }
} 