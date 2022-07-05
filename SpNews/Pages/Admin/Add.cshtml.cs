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
    public class AddModel : PageModel
    {
        private SpNewsContext _context;
        public AddModel(SpNewsContext context)
        {
            _context = context;
        }
        //map fields to inputs on page
        [BindProperty]
        public AddEditeNewsViewModel ToAddNewsVM{ get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var theNews = new News()
            {
                Name = ToAddNewsVM.Name,
                Description = ToAddNewsVM.Description,
                Date = ToAddNewsVM.Date,
            };
            _context.Add(theNews);
            _context.SaveChanges();
            if (ToAddNewsVM.Picture?.Length > 0)
            {
                string picPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    theNews.Id + Path.GetExtension(ToAddNewsVM.Picture.FileName));
                using (var stream = new FileStream(picPath, FileMode.Create))
                {
                    ToAddNewsVM.Picture.CopyTo(stream);
                }
            }
            return RedirectToPage("/index");
        }
    }
}
