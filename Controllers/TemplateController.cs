using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace AuthDemo.Controllers
{
    public class TemplateController : Controller
    {
        public IActionResult Page(string path)
        {
            if (string.IsNullOrEmpty(path))
                return Content("Path không hợp lệ.");

            // Đảm bảo path không chứa ký tự nguy hiểm
            path = path.Replace("..", "").Replace("\\", "/");
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pages", path + ".html");

            if (!System.IO.File.Exists(filePath))
                return Content($"Không tìm thấy file: {filePath}");

            var html = System.IO.File.ReadAllText(filePath);
            // Sửa lại các đường dẫn assets/partials/pages trong file html nếu cần
            html = html.Replace("assets/", "/assets/")
                       .Replace("partials/", "/partials/")
                       .Replace("pages/", "/pages/");
            return Content(html, "text/html");
        }
    }
} 