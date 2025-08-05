using AuthDemo.Areas.Admin.Interface;
using AuthDemo.Data;
using AuthDemo.Models;

namespace AuthDemo.Areas.Admin.Services
{
    public class ThuongHieuService : IThuongHieuService
    {
        private readonly ApplicationDbContext _db;
        public ThuongHieuService(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<ThuongHieu> GetAll()
        {
            try
            {
                return [.._db.ThuongHieus];
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách thương hiệu: " + ex.Message, ex);
            }
        }
        public ThuongHieu? GetById(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException("ID không hợp lệ!");
            try
            {
                return _db.ThuongHieus.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thương hiệu theo ID: " + ex.Message, ex);
            }
        }
        public void Add(ThuongHieu entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);
                _db.ThuongHieus.Add(entity);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm thương hiệu: " + ex.Message, ex);
            }
        }
        public void Update(ThuongHieu entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);
                var obj = _db.ThuongHieus.Find(entity.BrandID);
                ArgumentNullException.ThrowIfNull(obj, "Không tìm thấy thương hiệu để cập nhật!");
                _db.Entry(obj).CurrentValues.SetValues(entity);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật thương hiệu: " + ex.Message, ex);
            }
        }
        public void Delete(Guid id)
        {
            try
            {
                var obj = _db.ThuongHieus.Find(id);
                ArgumentNullException.ThrowIfNull(obj, "Không tìm thấy thương hiệu để xóa!");
                _db.ThuongHieus.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa thương hiệu: " + ex.Message, ex);
            }
        }
    }
} 