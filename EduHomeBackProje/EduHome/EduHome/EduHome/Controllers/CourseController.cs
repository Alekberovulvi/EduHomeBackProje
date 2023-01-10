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
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            CourseVM courseVM = new CourseVM
            {
                Courses = await _context.Courses.Include(x => x.CourseTags).Include(x => x.CourseImages).ToListAsync(),
                Subscribes = await _context.Subscribes.ToListAsync(),
                Settings = await _context.Settings.ToListAsync(),
            };
            return View(courseVM);
        }
        public async Task<IActionResult> Detail()
        {
            return View();
        }
    }
}
