using Microsoft.AspNetCore.Mvc;

namespace AuthDemo.Areas.NhanVien.Controllers
{
    [Area("NhanVien")]
    public class HomeNhanVienController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
