using Microsoft.AspNetCore.Mvc;
using AuthDemo.Data;
using AuthDemo.Areas.Admin.Interface;

namespace AuthDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HoaDonController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IHoaDonService _hoaDonService;
        public HoaDonController(ApplicationDbContext context, IHoaDonService hoaDonService)
        {
            db = context;
            _hoaDonService = hoaDonService;
        }
        public IActionResult Index()
        {
            var hoaDons = _hoaDonService.GetAllHoaDon();
            return View(hoaDons);
        }
    }
} 