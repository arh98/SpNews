using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpNews.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpNews.Controllers
{
    public class NewsController : Controller
    {
        private SpNewsContext _context;
        public NewsController(SpNewsContext context)
        {
            _context = context;
        }
        [Route("Group/{id}/{name}")]
        public IActionResult ShowByGroup(int id , string name)
        {
            ViewData["GroupName"] = name;
            var gpnews = _context.CategoryToNews
                .Where(c => c.CategoryId == id)
                .Include(n => n.News)
                .Select(n => n.News)
                .ToList();
            return View(gpnews);
        }
    }
}
