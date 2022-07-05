using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpNews.Data;
using SpNews.Models;

namespace SpNews.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private SpNewsContext _context;
        public IndexModel(SpNewsContext context)
        {
            _context = context;
        }
        public IEnumerable<News> AllNews { get; set; }
        public void OnGet()
        {
            AllNews = _context.News;
        }
        public void OnPost()
        {
        }
    }
}
