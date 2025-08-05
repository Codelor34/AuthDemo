using AuthDemo.Models;
using AuthDemo.Data;
using AuthDemo.Areas.Admin.Interface;

namespace AuthDemo.Areas.Admin.Services
{
    public class ChatLieuService : IChatLieuService
    {
        private readonly ApplicationDbContext _db;
        public ChatLieuService(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<ChatLieu> GetAll()
        {
            try
            {
                return [.._db.ChatLieus];
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách chất liệu: " + ex.Message, ex);
            }
        }
        public ChatLieu? GetById(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException("ID không hợp lệ!");
            try
            {
                return _db.ChatLieus.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy chất liệu theo ID: " + ex.Message, ex);
            }
        }
        public void Add(ChatLieu entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);
                _db.ChatLieus.Add(entity);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm chất liệu: " + ex.Message, ex);
            }
        }
        public void Update(ChatLieu entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);
                var obj = _db.ChatLieus.Find(entity.MaterialID);
                ArgumentNullException.ThrowIfNull(obj, "Không tìm thấy chất liệu để cập nhật!");
                _db.Entry(obj).CurrentValues.SetValues(entity);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật chất liệu: " + ex.Message, ex);
            }
        }
        public void Delete(Guid id)
        {
            try
            {
                var obj = _db.ChatLieus.Find(id);
                ArgumentNullException.ThrowIfNull(obj, "Không tìm thấy chất liệu để xóa!");
                _db.ChatLieus.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa chất liệu: " + ex.Message, ex);
            }
        }
    }
} 