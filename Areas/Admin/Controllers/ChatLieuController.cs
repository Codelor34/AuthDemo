using Microsoft.AspNetCore.Mvc;
using AuthDemo.Areas.Admin.Interface;
using AuthDemo.Models;

namespace AuthDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChatLieuController : Controller
    {
        private readonly IChatLieuService _chatLieuService;
        public ChatLieuController(IChatLieuService chatLieuService)
        {
            _chatLieuService = chatLieuService;
        }

        public IActionResult Index()
        {
            var list = _chatLieuService.GetAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ChatLieu model)
        {
            if (ModelState.IsValid)
            {
                _chatLieuService.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var cl = _chatLieuService.GetById(id);
            if (cl == null) return NotFound();
            return View(cl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ChatLieu model)
        {
            if (ModelState.IsValid)
            {
                _chatLieuService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(Guid id)
        {
            _chatLieuService.Delete(id);
            return RedirectToAction("Index");
        }
    }
} 