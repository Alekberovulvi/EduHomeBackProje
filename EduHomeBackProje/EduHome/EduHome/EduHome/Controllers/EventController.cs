using EduHome.DAL;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        public EventController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            EventVM eventVM = new EventVM
            {
                Events = await _context.Events.Include(x => x.EventSpeakers).ToListAsync(),
                Subscribes = await _context.Subscribes.ToListAsync(),
                Settings = await _context.Settings.ToListAsync()

            };
            return View(eventVM);
        }
        public async Task<IActionResult> Detail()
        {
            return View();
        }
    }
}
