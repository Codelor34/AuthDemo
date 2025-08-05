using AuthDemo.Models;
using AuthDemo.Data;
using AuthDemo.Areas.Admin.Interface;

namespace AuthDemo.Areas.Admin.Services
{
    public class MauSacService : IMauSacService
    {
        private readonly ApplicationDbContext _db;
        public MauSacService(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<MauSac> GetAll()
        {
            try
            {
                return [.._db.MauSacs];
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách màu sắc: " + ex.Message, ex);
            }
        }
        public MauSac?  GetById(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException("ID không hợp lệ!");
            try
            {
                return _db.MauSacs.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy màu sắc theo ID: " + ex.Message, ex);
            }
        }
        public void Add(MauSac entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);
                _db.MauSacs.Add(entity);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm màu sắc: " + ex.Message, ex);
            }
        }
        public void Update(MauSac entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);
                var obj = _db.MauSacs.Find(entity.ColorID);
                ArgumentNullException.ThrowIfNull(obj, "Không tìm thấy màu sắc để cập nhật!");
                _db.Entry(obj).CurrentValues.SetValues(entity);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật màu sắc: " + ex.Message, ex);
            }
        }
        public void Delete(Guid id)
        {
            try
            {
                var obj = _db.MauSacs.Find(id);
                ArgumentNullException.ThrowIfNull(obj, "Không tìm thấy màu sắc để xóa!");
                _db.MauSacs.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa màu sắc: " + ex.Message, ex);
            }
        }
    }
} 