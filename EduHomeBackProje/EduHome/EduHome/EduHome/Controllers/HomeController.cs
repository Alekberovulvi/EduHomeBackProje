using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Sliders = await _context.Sliders.OrderBy(x => x.Order).ToListAsync(),
                Courses = await _context.Courses.Include(x => x.CourseTags).Include(x => x.CourseImages).Take(3).ToListAsync(),
                Events = await _context.Events.Include(x => x.EventSpeakers).ToListAsync(),
                Promotions = await _context.Promotions.ToListAsync(),
                Testimonials = await _context.Testimonials.ToListAsync(),
                Settings = await _context.Settings.ToListAsync(),
                NoticeBoards = await _context.NoticeBoards.ToListAsync(),
                Subscribes = await _context.Subscribes.ToListAsync(),
            };
            return View(homeVM);
        }
    }
}