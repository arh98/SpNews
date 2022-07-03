using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using SpNews.Data;
using SpNews.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SpNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SpNewsContext _context;

        public HomeController(ILogger<HomeController> logger , SpNewsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var newsItems = _context.News.ToList();
            return View(newsItems);
        }
        public IActionResult Detailed(int id)
        {
            var news = _context.News.Find(id);
            if (news == null)
                return NotFound();
            var categoriesOfNews = _context.News.Where(n => n.Id == id)
                .SelectMany(c => c.CategoryToNews)
                .Select(cat => cat.Category).ToList();
            var dvm = new DetailedViewModel()
            {
                News = news,
                Categories = categoriesOfNews
            };
            return View(dvm);
             
        }
        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
