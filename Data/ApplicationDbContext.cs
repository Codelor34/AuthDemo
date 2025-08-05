using Microsoft.EntityFrameworkCore;
using AuthDemo.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace AuthDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<VaiTro> VaiTros { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<Giay> Giays { get; set; }
        public DbSet<ChiTietGiay> ChiTietGiays { get; set; }
        public DbSet<AnhGiay> AnhGiays { get; set; }
        public DbSet<ChatLieu> ChatLieus { get; set; }
        public DbSet<MauSac> MauSacs { get; set; }
        public DbSet<KichThuoc> KichThuocs { get; set; }
        public DbSet<ThuongHieu> ThuongHieus { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<LichSuHoaDon> LichSuHoaDons { get; set; }
        public DbSet<DiaChi> DiaChis { get; set; }
        public DbSet<VaiTroNguoiDung> VaiTroNguoiDungs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AuthDemo.Models.Configurations.NguoiDungConfiguration());
            modelBuilder.ApplyConfiguration(new AuthDemo.Models.Configurations.VaiTroConfiguration());
            modelBuilder.ApplyConfiguration(new AuthDemo.Models.Configurations.DanhMucConfiguration());
            modelBuilder.ApplyConfiguration(new AuthDemo.Models.Configurations.GiayConfiguration());
            modelBuilder.ApplyConfiguration(new AuthDemo.Models.Configurations.ChiTietGiayConfiguration());
            modelBuilder.ApplyConfiguration(new AuthDemo.Models.Configurations.AnhGiayConfiguration());
            modelBuilder.ApplyConfiguration(new AuthDemo.Models.Configurations.ChatLieuConfiguration());
            modelBuilder.ApplyConfiguration(new AuthDemo.Models.Configurations.MauSacConfiguration());
            modelBuilder.ApplyConfiguration(new AuthDemo.Models.Configurations.KichThuocConfiguration());
            modelBuilder.ApplyConfiguration(new AuthDemo.Models.Configurations.ThuongHieuConfiguration());
            modelBuilder.ApplyConfiguration(new AuthDemo.Models.Configurations.GioHangConfiguration());
            modelBuilder.ApplyConfiguration(new AuthDemo.Models.Configurations.ChiTietGioHangConfiguration());
            modelBuilder.ApplyConfiguration(new AuthDemo.Models.Configurations.HoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new AuthDemo.Models.Configurations.ChiTietHoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new AuthDemo.Models.Configurations.LichSuHoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new AuthDemo.Models.Configurations.DiaChiConfiguration());
            modelBuilder.ApplyConfiguration(new AuthDemo.Models.Configurations.VaiTroNguoiDungConfiguration());
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is ThongTinChung && (e.State == EntityState.Added || e.State == EntityState.Modified));
            var user = _httpContextAccessor.HttpContext?.Session?.GetString("TenDangNhap") ?? "system";
            var now = DateTime.Now;
            foreach (var entry in entries)
            {
                var entity = (ThongTinChung)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    entity.NgayTao = now;
                    entity.NguoiTao = user;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property(nameof(ThongTinChung.NguoiTao)).IsModified = false;
                    entry.Property(nameof(ThongTinChung.NgayTao)).IsModified = false;
                }
                entity.NgayCapNhat = now;
                entity.NguoiCapNhat = user;
            }
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is ThongTinChung && (e.State == EntityState.Added || e.State == EntityState.Modified));
            var user = _httpContextAccessor.HttpContext?.Session?.GetString("TenDangNhap") ?? "system";
            var now = DateTime.Now;
            foreach (var entry in entries)
            {
                var entity = (ThongTinChung)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    entity.NgayTao = now;
                    entity.NguoiTao = user;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property(nameof(ThongTinChung.NguoiTao)).IsModified = false;
                    entry.Property(nameof(ThongTinChung.NgayTao)).IsModified = false;
                }
                entity.NgayCapNhat = now;
                entity.NguoiCapNhat = user;
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
} 