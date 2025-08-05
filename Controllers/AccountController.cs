using Microsoft.AspNetCore.Mvc;
using AuthDemo.Models;
using AuthDemo.Data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AuthDemo.Helpers;

namespace AuthDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ApplicationDbContext context, ILogger<AccountController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthDemo.Models.ViewModels.LoginViewModel model)
        {
            // Ghi log: Bắt đầu đăng nhập
            _logger.LogInformation($"Login attempt for username: {model.TenDangNhap}");
            // Kiểm tra dữ liệu đầu vào hợp lệ
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Tìm user theo tên đăng nhập, kèm theo các vai trò
            var user = await _context.NguoiDungs
                .Include(u => u.VaiTroNguoiDungs)
                    .ThenInclude(vtnd => vtnd.VaiTro)
                .FirstOrDefaultAsync(u => u.TenDangNhap == model.TenDangNhap);
            if (user == null)
            {
                // Không tìm thấy user
                _logger.LogWarning($"User not found: {model.TenDangNhap}");
                ModelState.AddModelError("", "Tên đăng nhập không tồn tại");
                return View(model);
            }
            // Hash mật khẩu nhập vào và so sánh với DB
            var passwordHash = HashPassword(model.MatKhau);
            _logger.LogInformation($"Password check - Input hash: {passwordHash}, DB hash: {user.MatKhau}");
            if (user.MatKhau != passwordHash)
            {
                // Sai mật khẩu
                _logger.LogWarning($"Password mismatch for user: {model.TenDangNhap}");
                ModelState.AddModelError("", "Mật khẩu không đúng");
                return View(model);
            }
            // Lấy danh sách tên vai trò của user (có thể chứa null)
            var tenVaiTroList = user.VaiTroNguoiDungs?
                    .Select(x => x.VaiTro?.TenVaiTro)
                .ToList() ?? new List<string?>();
            // Lưu thông tin đăng nhập vào session
            HttpContext.Session.SetString("TenDangNhap", user.TenDangNhap);
            HttpContext.Session.SetString("VaiTro", string.Join(",", tenVaiTroList));
            // Loại bỏ các phần tử null khỏi danh sách vai trò để kiểm tra
            var vaiTroListNonNull = tenVaiTroList.Where(x => x != null).Cast<string>();
            // Nếu user có cả vai trò admin và user, chuyển sang trang chọn vai trò
            if (RoleHelper.HasBothAdminAndUser(vaiTroListNonNull))
            {
                TempData["RoleChoice"] = "both";
                return RedirectToAction("ChooseRole");
            }
            // Nếu chỉ có admin, chuyển thẳng vào trang admin
            if (RoleHelper.IsAdmin(vaiTroListNonNull))
            {
            return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
            }
            // Nếu chỉ có nhân viên, chuyển vào trang nhân viên
            if (RoleHelper.IsNhanVien(vaiTroListNonNull))
            {
                return RedirectToAction("Index", "HomeNhanVien", new { area = "NhanVien" });
            }
            // Nếu chỉ có user, chuyển vào trang người dùng
            if (RoleHelper.IsUser(vaiTroListNonNull))
            {
                // Chuyển về Home/Index (Razor View)
                return RedirectToAction("Index", "Home");
            }
            
           
            // Nếu không có quyền hợp lệ, báo lỗi
            ModelState.AddModelError("", "Bạn không có quyền truy cập.");
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(NguoiDung model)
        {
            if (ModelState.IsValid)
            {
                if (await _context.NguoiDungs.AnyAsync(u => u.TenDangNhap == model.TenDangNhap))
                {
                    ModelState.AddModelError("TenDangNhap", "Tên đăng nhập đã tồn tại");
                    return View(model);
                }

                model.MatKhau = HashPassword(model.MatKhau);
                _context.NguoiDungs.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // Action để debug - tạo hash cho mật khẩu
        public IActionResult DebugHash(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return Content("Vui lòng nhập mật khẩu: /Account/DebugHash?password=yourpassword");
            }
            
            var hash = HashPassword(password);
            return Content($"Password: {password}\nHash: {hash}");
        }

        // Action để xem danh sách user trong database
        public async Task<IActionResult> DebugUsers()
        {
            var users = await _context.NguoiDungs
                .Include(u => u.VaiTroNguoiDungs)
                    .ThenInclude(vtnd => vtnd.VaiTro)
                .ToListAsync();
            var result = "Danh sách users:\n";
            
            foreach (var user in users)
            {
                var vaiTros = user.VaiTroNguoiDungs?
                    .Select(x => x.VaiTro?.TenVaiTro)
                    .ToList() ?? new List<string?>();
                result += $"TenDangNhap: {user.TenDangNhap}, VaiTro: {string.Join(",", vaiTros)}, MatKhau: {user.MatKhau}\n";
            }
            
            return Content(result);
        }

        // Action để test redirect
        public IActionResult TestRedirect()
        {
            return RedirectToAction("Index", "Home");
        }

        // Action để test login trực tiếp
        public async Task<IActionResult> TestLogin(string tenDangNhap)
        {
            var user = await _context.NguoiDungs
                .Include(u => u.VaiTroNguoiDungs)
                    .ThenInclude(vtnd => vtnd.VaiTro)
                .FirstOrDefaultAsync(u => u.TenDangNhap == tenDangNhap);
            if (user == null)
            {
                return Content($"User {tenDangNhap} not found");
            }

            var tenVaiTroList = user.VaiTroNguoiDungs?
                .Select(x => x.VaiTro?.TenVaiTro)
                .ToList() ?? new List<string?>();

            HttpContext.Session.SetString("TenDangNhap", user.TenDangNhap);
            HttpContext.Session.SetString("VaiTro", string.Join(",", tenVaiTroList));

            var vaiTroListNonNull = tenVaiTroList.Where(x => x != null).Cast<string>();
            if (tenVaiTroList.Any(vt => vt?.ToLower() == "admin" || vt?.ToLower() == "quản lý"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public IActionResult ChooseRole()
        {
            // View sẽ hiện 2 nút: Vào Admin hoặc Vào Home
            return View();
        }

        [HttpPost]
        public IActionResult ChooseRole(string role)
        {
            if (role == "admin")
                return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
            else if (role == "NhanVien")
                return RedirectToAction("Index", "HomeNhanVien", new { area = "NhanVien" });
            else if (role == "user")
                return RedirectToAction("Index", "Home");
            else
                return RedirectToAction("Login");

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