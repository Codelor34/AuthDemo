using Microsoft.AspNetCore.Mvc;
using AuthDemo.Areas.Admin.Interface;
using AuthDemo.Models;

namespace AuthDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThuongHieuController : Controller
    {
        private readonly IThuongHieuService _thuongHieuService;
        public ThuongHieuController(IThuongHieuService thuongHieuService)
        {
            _thuongHieuService = thuongHieuService;
        }

        public IActionResult Index()
        {
            var list = _thuongHieuService.GetAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ThuongHieu model)
        {
            if (ModelState.IsValid)
            {
                _thuongHieuService.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var hang = _thuongHieuService.GetById(id);
            if (hang == null) return NotFound();
            return View(hang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ThuongHieu model)
        {
            if (ModelState.IsValid)
            {
                _thuongHieuService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(Guid id)
        {
            _thuongHieuService.Delete(id);
            return RedirectToAction("Index");
        }
    }
} 