using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpNews.Data;
using SpNews.Models;

namespace SpNews.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private SpNewsContext _context;
        public DeleteModel(SpNewsContext context)
        {
            _context = context;
        }
        [BindProperty]
        public News ToDeleteNews { get; set; }
        public void OnGet(int id)
        {
            ToDeleteNews = _context.News.FirstOrDefault(n => n.Id == id);

        }
        public IActionResult OnPost()
        {
            var theNews = _context.News.Find(ToDeleteNews.Id);
            _context.News.Remove(theNews);

            _context.SaveChanges();
            return RedirectToPage("index");
        }
    }
}
