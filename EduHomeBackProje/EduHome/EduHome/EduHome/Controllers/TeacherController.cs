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
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        public TeacherController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            TeacherVM teacherVM = new TeacherVM
            {
                Settings = await _context.Settings.ToListAsync(),
                Teachers = await _context.Teachers.Include(x => x.Courses).ToListAsync(),
                Subscribes = await _context.Subscribes.ToListAsync(),
            };
            return View(teacherVM);
        }
        public async Task<IActionResult> Detail()
        {
            return View();
        }
    }
}
