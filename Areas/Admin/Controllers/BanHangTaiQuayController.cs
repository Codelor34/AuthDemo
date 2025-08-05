using Microsoft.AspNetCore.Mvc;
using AuthDemo.Data;
using AuthDemo.Models;
using AuthDemo.Areas.Admin.Interface;
using AuthDemo.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using AuthDemo.Models.Enums;

namespace DATN_Lor.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BanHangTaiQuayController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IBanHangTaiQuayService _banHangTaiQuayService;
        public BanHangTaiQuayController(ApplicationDbContext db, IBanHangTaiQuayService banHangTaiQuayService)
        {
            _db = db;
            _banHangTaiQuayService = banHangTaiQuayService;
        }
        // GET: Admin/BanHangTaiQuay
        public IActionResult Index()
        {
            var tuVanSanPham = _banHangTaiQuayService.SearchSanPham("");
            ViewBag.TuVanSanPham = tuVanSanPham;

            // Truyền enum phương thức thanh toán và vận chuyển sang view với tên tiếng Việt
            ViewBag.PhuongThucThanhToanList = Enum.GetValues(typeof(PhuongThucThanhToan))
                .Cast<PhuongThucThanhToan>()
                .Select(e => new { Value = (int)e, Name = e.GetDisplayName() })
                .ToList();
            ViewBag.PhuongThucVanChuyenList = Enum.GetValues(typeof(PhuongThucVanChuyen))
                .Cast<PhuongThucVanChuyen>()
                .Select(e => new { Value = (int)e, Name = e.GetDisplayName() })
                .ToList();

            var tenDangNhap = HttpContext.Session.GetString("TenDangNhap");
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                ViewBag.CartItems = new List<CartItemDisplayVM>();
                ViewBag.Error = "Không tìm thấy thông tin đăng nhập người dùng.";
                return View();
            }
            var cartItems = _banHangTaiQuayService.GetCartItems(tenDangNhap); // Đã là List<CartItemDisplayVM>
            ViewBag.CartItems = cartItems;
            return View();
        }

        [HttpGet]
        public JsonResult SearchSanPham(string keyword)
        {
            var result = _banHangTaiQuayService.SearchSanPham(keyword);
            return Json(result);
        }

        [HttpGet]
        public IActionResult GetCartItems()
        {
            var tenDangNhap = HttpContext.Session.GetString("TenDangNhap");
            if (string.IsNullOrEmpty(tenDangNhap))
                return BadRequest("Không tìm thấy thông tin đăng nhập người dùng.");
            var cartItems = _banHangTaiQuayService.GetCartItems(tenDangNhap);
            return Json(cartItems);
        }

        [HttpPost]
        public IActionResult UpdateCart(Guid shoeDetailId, string actionType)
        {
            var tenDangNhap = HttpContext.Session.GetString("TenDangNhap");
            if (string.IsNullOrEmpty(tenDangNhap))
                return BadRequest("Không tìm thấy thông tin đăng nhập người dùng.");
            _banHangTaiQuayService.UpdateCart(tenDangNhap, shoeDetailId, actionType);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateDiscountCartItem(Guid cartDetailId, decimal? chietKhauPhanTram, decimal? chietKhauTienMat, bool? isTangKem, string reason)
        {
            _banHangTaiQuayService.UpdateDiscountCartItem(cartDetailId, chietKhauPhanTram, chietKhauTienMat, isTangKem, reason);
            return Ok();
        }

        [HttpGet]
        public JsonResult SearchKhachHang(string keyword)
        {
            var users = _banHangTaiQuayService.SearchKhachHang(keyword);
            return Json(users);
        }
    }
} 