using AuthDemo.Models;
using AuthDemo.Data;
using AuthDemo.Areas.Admin.Interface;
using AuthDemo.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AuthDemo.Areas.Admin.Services
{
    public class GiayService : IGiayService
    {
        private readonly ApplicationDbContext _db;
        public GiayService(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Giay> GetAll()
        {
            try
            {
                return [.._db.Giays];
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm: " + ex.Message, ex);
            }
        }
            public Giay? GetById(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException("ID không hợp lệ!");
            try
            {
                return _db.Giays.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy sản phẩm theo ID: " + ex.Message, ex);
            }
        }
        public void Add(Giay entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);
                _db.Giays.Add(entity);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm sản phẩm: " + ex.Message, ex);
            }
        }
        public void Update(Giay entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);
                var obj = _db.Giays.Find(entity.ShoeID);
                ArgumentNullException.ThrowIfNull(obj, "Không tìm thấy sản phẩm để cập nhật!");
                _db.Entry(obj).CurrentValues.SetValues(entity);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật sản phẩm: " + ex.Message, ex);
            }
        }
        public void Delete(Guid id)
        {
            try
            {
                var obj = _db.Giays.Find(id);
                ArgumentNullException.ThrowIfNull(obj, "Không tìm thấy sản phẩm để xóa!");
                _db.Giays.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa sản phẩm: " + ex.Message, ex);
            }
        }
        public IEnumerable<GiayFullInfoVM> GetGiayFullInfoList()
        {
            var giayList = _db.Giays
                .Select(g => new GiayFullInfoVM
                {
                    Giay = g,
                    MaGiayCode = g.MaGiayCode,
                    MoTa = g.MoTa,
                    ChiTietGiays = _db.ChiTietGiays
                        .Where(ct => ct.ShoeID == g.ShoeID)
                        .Select(ct => new ChiTietGiay
                        {
                            ShoeDetailID = ct.ShoeDetailID,
                            ShoeID = ct.ShoeID,
                            SizeID = ct.SizeID,
                            ColorID = ct.ColorID,
                            MaterialID = ct.MaterialID,
                            BrandID = ct.BrandID,
                            CategoryID = ct.CategoryID,
                            SoLuong = ct.SoLuong,
                            Gia = ct.Gia,
                            KichThuoc = ct.KichThuoc,
                            MauSac = ct.MauSac,
                            ChatLieu = ct.ChatLieu,
                            ThuongHieu = ct.ThuongHieu
                        }).ToList(),
                    TenDanhMuc = _db.ChiTietGiays
                        .Where(ct => ct.ShoeID == g.ShoeID)
                        .Select(ct => ct.DanhMuc != null ? ct.DanhMuc.TenDanhMuc : null)
                        .FirstOrDefault() ?? "Chưa có",
                    TenThuongHieu = _db.ChiTietGiays
                        .Where(ct => ct.ShoeID == g.ShoeID)
                        .Select(ct => ct.ThuongHieu != null ? ct.ThuongHieu.TenThuongHieu : null)
                        .FirstOrDefault() ?? "Chưa có",
                    TenChatLieu = _db.ChiTietGiays
                        .Where(ct => ct.ShoeID == g.ShoeID)
                        .Select(ct => ct.ChatLieu != null ? ct.ChatLieu.TenChatLieu : null)
                        .FirstOrDefault() ?? "Chưa có"
                }).ToList();
            return giayList;
        }
    }
} 