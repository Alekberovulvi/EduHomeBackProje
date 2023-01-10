using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Manage.Controllers
{
    [Area("manage")]

    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public EventController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Events.Count() / 2d);

            List<Event> events = _context.Events.Include(x => x.EventSpeakers).Skip((page - 1) * 2).Take(2).ToList();
            return View(events);
        }

        public IActionResult Create()
        {
            ViewBag.Speakers = _context.Speakers.ToList();
            ViewBag.Categories = _context.Categories.ToList();

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Event _event)
        {
            
            ViewBag.Speakers = _context.Speakers.ToList();
            ViewBag.Categories = _context.Categories.ToList();

            if (!_context.Speakers.Any(x => x.Id == _event.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Xeta var!");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Events.Add(_event);
            _context.SaveChanges();


            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Event _event = _context.Events.Include(x => x.EventSpeakers).FirstOrDefault(x => x.Id == id);

            if (_event == null) return RedirectToAction("index");

            ViewBag.Speakers = _context.Speakers.ToList();
            ViewBag.Categories = _context.Categories.ToList();

            return View(_event);
        }

    }
}
