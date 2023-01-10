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
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            AboutVM aboutVM = new AboutVM
            {
                Promotions = await _context.Promotions.ToListAsync(),
                Testimonials = await _context.Testimonials.ToListAsync(),
                Settings = await _context.Settings.ToListAsync(),
                Teachers = await _context.Teachers.Include(x => x.Courses).Take(4).ToListAsync(),
                Subscribes = await _context.Subscribes.ToListAsync(),
                NoticeBoards = await _context.NoticeBoards.ToListAsync(),
            };
            return View(aboutVM);
        }
    }
}
