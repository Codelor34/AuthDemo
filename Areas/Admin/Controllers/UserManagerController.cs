using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthDemo.Data;
using AuthDemo.Models;
using System.Security.Cryptography;
using System.Text;
using AuthDemo.Models.ViewModels;

namespace AuthDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserManagerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const int PageSize = 10;

        public UserManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Danh sách tài khoản
        public async Task<IActionResult> Index(string search, int page = 1)
        {
            var query = from u in _context.NguoiDungs
                        join ur in _context.VaiTroNguoiDungs on u.UserID equals ur.UserID into urJoin
                        from ur in urJoin.DefaultIfEmpty()
                        join r in _context.VaiTros on ur.RoleID equals r.RoleID into rJoin
                        from r in rJoin.DefaultIfEmpty()
                        where u.IsActive
                        select new UserWithRoleVM
                        {
                            UserID = u.UserID,
                            TenDangNhap = u.TenDangNhap,
                            HoTen = u.HoTen,
                            Email = u.Email,
                            SoDienThoai = u.SoDienThoai,
                            IsActive = u.IsActive,
                            TenVaiTro = r != null ? r.TenVaiTro : ""
                        };
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(u => u.TenDangNhap.Contains(search) || u.TenVaiTro.Contains(search));
            }
            int total = await query.CountAsync();
            var users = await query.OrderBy(u => u.TenDangNhap)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
            ViewBag.Total = total;
            ViewBag.Page = page;
            ViewBag.PageSize = PageSize;
            ViewBag.Search = search;
            return View(users);
        }

        // GET: Thêm tài khoản
        public IActionResult Create()
        {
            ViewBag.Roles = _context.VaiTros.ToList();
            return View();
        }

        // POST: Thêm tài khoản
        [HttpPost]
        public async Task<IActionResult> Create(UserManagerVM model)
        {
            if (ModelState.IsValid)
            {
                if (await _context.NguoiDungs.AnyAsync(u => u.TenDangNhap == model.TenDangNhap))
                {
                    ModelState.AddModelError("TenDangNhap", "Tên đăng nhập đã tồn tại");
                    ViewBag.Roles = _context.VaiTros.ToList();
                    return View(model);
                }
                // Map từ VM sang entity
                var entity = new NguoiDung
                {
                    UserID = Guid.NewGuid(),
                    TenDangNhap = model.TenDangNhap,
                    MatKhau = HashPassword(model.MatKhau),
                    IsActive = true,
                    NguoiTao = User.Identity?.Name ?? "admin",
                    NgayTao = DateTime.Now,
                    NguoiCapNhat = User.Identity?.Name ?? "admin",
                    NgayCapNhat = DateTime.Now
                };
                _context.NguoiDungs.Add(entity);
                await _context.SaveChangesAsync();
                // Gán vai trò
                if (model.RoleID.HasValue)
                {
                    var userRole = new VaiTroNguoiDung { UserID = entity.UserID, RoleID = model.RoleID.Value };
                    _context.VaiTroNguoiDungs.Add(userRole);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            ViewBag.Roles = _context.VaiTros.ToList();
            return View(model);
        }

        // GET: Sửa tài khoản
        public async Task<IActionResult> EditUser(Guid id)
        {
            var user = await _context.NguoiDungs.FirstOrDefaultAsync(u => u.UserID == id);
            if (user == null) return NotFound();
            var userRole = await _context.VaiTroNguoiDungs.FirstOrDefaultAsync(ur => ur.UserID == id);
            ViewBag.Roles = _context.VaiTros.ToList();
            ViewBag.RoleID = userRole?.RoleID;
            return View("EditUser", user);
        }

        // POST: Sửa tài khoản
        [HttpPost]
        public async Task<IActionResult> EditUser(NguoiDung model, Guid RoleID)
        {
            if (string.IsNullOrEmpty(model.MatKhau))
            ModelState.Remove("MatKhau");
            ModelState.Remove("VaiTroNguoiDungs");
            if (ModelState.IsValid)
            {
                var user = await _context.NguoiDungs.FirstOrDefaultAsync(u => u.UserID == model.UserID);
                if (user == null) return NotFound();
                user.HoTen = model.HoTen;
                user.Email = model.Email;
                user.SoDienThoai = model.SoDienThoai;
                user.IsActive = model.IsActive;
                if (!string.IsNullOrEmpty(model.MatKhau))
                    user.MatKhau = HashPassword(model.MatKhau);
                // Cập nhật vai trò
                var userRole = await _context.VaiTroNguoiDungs.FirstOrDefaultAsync(ur => ur.UserID == user.UserID);
                if (userRole != null)
                {
                    userRole.RoleID = RoleID;
                }
                else
                {
                    _context.VaiTroNguoiDungs.Add(new VaiTroNguoiDung { UserID = user.UserID, RoleID = RoleID });
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Roles = _context.VaiTros.ToList();
            ViewBag.RoleID = RoleID;
            return View("EditUser", model);
        }

        // Xóa mềm tài khoản
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _context.NguoiDungs.FindAsync(id);
            if (user == null) return NotFound();
            user.IsActive = false;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
} 