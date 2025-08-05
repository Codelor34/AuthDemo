using Microsoft.AspNetCore.Mvc;
using AuthDemo.Areas.Admin.Interface;
using AuthDemo.Models;

namespace AuthDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MauSacController : Controller
    {
        private readonly IMauSacService _mauSacService;
        public MauSacController(IMauSacService mauSacService)
        {
            _mauSacService = mauSacService;
        }

        public IActionResult Index()
        {
            var list = _mauSacService.GetAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MauSac model)
        {
            if (ModelState.IsValid)
            {
                _mauSacService.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var ms = _mauSacService.GetById(id);
            if (ms == null) return NotFound();
            return View(ms);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MauSac model)
        {
            if (ModelState.IsValid)
            {
                _mauSacService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(Guid id)
        {
            _mauSacService.Delete(id);
            return RedirectToAction("Index");
        }
    }
} 