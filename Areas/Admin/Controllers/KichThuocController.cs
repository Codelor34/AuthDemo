using Microsoft.AspNetCore.Mvc;
using AuthDemo.Areas.Admin.Interface;
using AuthDemo.Models;

namespace AuthDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KichThuocController : Controller
    {
        private readonly IKichThuocService _sizeService;
        public KichThuocController(IKichThuocService sizeService)
        {
            _sizeService = sizeService;
        }

        public IActionResult Index()
        {
            var list = _sizeService.GetAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KichThuoc model)
        {
            if (ModelState.IsValid)
            {
                _sizeService.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var sz = _sizeService.GetById(id);
            if (sz == null) return NotFound();
            return View(sz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(KichThuoc model)
        {
            if (ModelState.IsValid)
            {
                _sizeService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(Guid id)
        {
            _sizeService.Delete(id);
            return RedirectToAction("Index");
        }
    }
} 