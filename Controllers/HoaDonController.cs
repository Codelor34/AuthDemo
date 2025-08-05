using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthDemo.Models;
using AuthDemo.Data;

namespace Controllers
{
    public class HoaDonController : Controller
    {
        private readonly ApplicationDbContext db;
        public HoaDonController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        // public IActionResult DanhSach()
        // {
        //     var lstDH= db.Don_Hang_Thanh_Toans.ToList();
        //     return View(lstDH); 
        // }
        [HttpPost]
        public IActionResult TrangThai()
        {
            return View();
        }
    }
}
