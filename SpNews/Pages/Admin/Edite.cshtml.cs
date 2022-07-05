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
    public class EditeModel : PageModel
    {
        private SpNewsContext _context;
        public EditeModel(SpNewsContext context)
        {
            _context = context;
        }
        [BindProperty]
        public AddEditeNewsViewModel ToEditeNewsVM { get; set; }
        public void OnGet(int id)
        {
                 var TheNews = _context.News
                .Where(n => n.Id == id)
                .Select(s => new AddEditeNewsViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Date = s.Date
                }).FirstOrDefault();
            ToEditeNewsVM = TheNews;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var theNews = _context.News.Find(ToEditeNewsVM.Id);

            theNews.Name = ToEditeNewsVM.Name;
            theNews.Description = ToEditeNewsVM.Description;
            theNews.Date = ToEditeNewsVM.Date;
            _context.SaveChanges();
            if (ToEditeNewsVM.Picture?.Length > 0)
            {
                string picPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    theNews.Id + Path.GetExtension(ToEditeNewsVM.Picture.FileName));
                using (var stream = new FileStream(picPath, FileMode.Create))
                {
                    ToEditeNewsVM.Picture.CopyTo(stream);
                }
            }
            return RedirectToPage("index");
        }
    }
}
