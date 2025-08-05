using AuthDemo.Models;
using AuthDemo.Data;
using AuthDemo.Areas.Admin.Interface;

namespace AuthDemo.Areas.Admin.Services
{
    public class KichThuocService : IKichThuocService
    {
        private readonly ApplicationDbContext _db;
        public KichThuocService(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<KichThuoc> GetAll()
        {
            try
            {
                return [.._db.KichThuocs];
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách kích thước: " + ex.Message, ex);
            }
        }
        public KichThuoc? GetById(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException("ID không hợp lệ!");
            try
            {
                return _db.KichThuocs.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy kích thước theo ID: " + ex.Message, ex);
            }
        }
        public void Add(KichThuoc entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);
                _db.KichThuocs.Add(entity);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm kích thước: " + ex.Message, ex);
            }
        }
        public void Update(KichThuoc entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);
                var obj = _db.KichThuocs.Find(entity.SizeID);
                ArgumentNullException.ThrowIfNull(obj, "Không tìm thấy kích thước để cập nhật!");
                _db.Entry(obj).CurrentValues.SetValues(entity);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật kích thước: " + ex.Message, ex);
            }
        }
        public void Delete(Guid id)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(id);
                var obj = _db.KichThuocs.Find(id);
                ArgumentNullException.ThrowIfNull(obj, "Không tìm thấy kích thước để xóa!");
                _db.KichThuocs.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa kích thước: " + ex.Message, ex);
            }
        }
    }
} 