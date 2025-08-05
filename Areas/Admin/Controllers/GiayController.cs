using Microsoft.AspNetCore.Mvc;
using AuthDemo.Areas.Admin.Interface;
using AuthDemo.Models;
using AuthDemo.Data;
using AuthDemo.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AuthDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GiayController : Controller
    {
        private readonly IGiayService _sanPhamService;
        private readonly ApplicationDbContext _db;
        public GiayController(IGiayService sanPhamService, ApplicationDbContext db)
        {
            _sanPhamService = sanPhamService;
            _db = db;
        }

        public IActionResult Index()
        {
            var list = _sanPhamService.GetAll().ToList();
            var tongSoLuongDict = _db.ChiTietGiays
                .GroupBy(ct => ct.ShoeID)
                .ToDictionary(g => g.Key, g => g.Sum(ct => ct.SoLuong));
            var giayEntities = _db.Giays.AsNoTracking().ToList();

            var viewModel = list.Select(g => {
                var giayDb = giayEntities.FirstOrDefault(x => x.ShoeID == g.ShoeID);
                return new GiayWithSoLuongVM
                {
                    Giay = g,
                    TongSoLuong = tongSoLuongDict.ContainsKey(g.ShoeID) ? tongSoLuongDict[g.ShoeID] : 0,
                    NguoiCapNhat = giayDb?.NguoiCapNhat,
                    NgayCapNhat = giayDb?.NgayCapNhat,
                    NguoiTao = giayDb?.NguoiTao,
                    NgayTao = giayDb?.NgayTao
                };
            }).ToList();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Giay model)
        {
            if (ModelState.IsValid)
            {
                _sanPhamService.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var giay = _sanPhamService.GetById(id);
            if (giay == null) return NotFound();

            var vm = new GiayVM
            {
                ShoeID = giay.ShoeID,
                TenGiay = giay.TenGiay,
                MaGiayCode = giay.MaGiayCode,
                MoTa = giay.MoTa,
                TrangThai = giay.TrangThai,
                NguoiCapNhat = giay.NguoiCapNhat,
                NgayCapNhat = giay.NgayCapNhat
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GiayVM vm)
        {
            var giay = _sanPhamService.GetById(vm.ShoeID);
            if (giay == null) return NotFound();

            giay.TenGiay = vm.TenGiay;
            giay.MaGiayCode = vm.MaGiayCode;
            giay.MoTa = vm.MoTa;
            giay.TrangThai = vm.TrangThai;
            giay.NguoiCapNhat = User.Identity?.Name ?? "ad";
            giay.NgayCapNhat = DateTime.Now;

            if (ModelState.IsValid)
            {
                _sanPhamService.Update(giay);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        public IActionResult Delete(Guid id)
        {
            _sanPhamService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            var giay = _db.Giays.Find(id);
            if (giay == null) return NotFound();
            var chiTietList = _db.ChiTietGiays
                .Include(ct => ct.DanhMuc)
                .Include(ct => ct.ThuongHieu)
                .Include(ct => ct.ChatLieu)
                .Include(ct => ct.KichThuoc)
                .Include(ct => ct.MauSac)
                .Where(ct => ct.ShoeID == id)
                .ToList();
            var firstDetail = chiTietList.FirstOrDefault();
            var viewModel = new GiayFullInfoVM
            {
                Giay = giay,
                TenDanhMuc = firstDetail?.DanhMuc?.TenDanhMuc ?? "",
                TenThuongHieu = firstDetail?.ThuongHieu?.TenThuongHieu ?? "",
                TenChatLieu = firstDetail?.ChatLieu?.TenChatLieu ?? "",
                ChiTietGiays = chiTietList,
                TongSoLuong = chiTietList.Sum(ct => ct.SoLuong)
            };
            return View(viewModel);
        }
    }
} 