using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.ViewModels;
using EduHome.DAL;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            BlogVM blogVM = new BlogVM
            {
                Subscribes = await _context.Subscribes.ToListAsync(),
                Settings = await _context.Settings.ToListAsync()
            };
            return View(blogVM);
        }
        public async Task<IActionResult> Detail()
        {
            return View();
        }
    }
}
