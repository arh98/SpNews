using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpNews.Data;
using SpNews.Models;

namespace SpNews.Pages.Admin.UsersManagment
{
    public class IndexModel : PageModel
    {
        private readonly SpNews.Data.SpNewsContext _context;

        public IndexModel(SpNews.Data.SpNewsContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.Users.ToListAsync();
        }
    }
}
