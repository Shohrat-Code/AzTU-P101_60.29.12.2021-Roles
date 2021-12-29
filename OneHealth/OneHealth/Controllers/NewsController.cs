using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneHealth.Data;
using OneHealth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneHealth.Controllers
{
    public class NewsController : Controller
    {
        private readonly AppDbContext _context;

        public NewsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            VmHome model = new VmHome();
            model.Setting = _context.Settings.FirstOrDefault();
            model.Socials = _context.Socials.ToList();
            model.Blogs = _context.Blogs.Include(u => u.CustomUser).ToList();
            model.Categories = _context.Categories.Include(b => b.Blogs).ToList();
            model.Tags = _context.Tags.ToList();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            VmHome model = new VmHome();
            model.Setting = _context.Settings.FirstOrDefault();
            model.Socials = _context.Socials.ToList();
            model.Blog = _context.Blogs
                                 .Include(u => u.CustomUser)
                                 .Include(tg => tg.TagToBlogs).ThenInclude(t => t.Tag)
                                 .FirstOrDefault(b => b.Id == id);

            return View(model);
        }
    }
}
