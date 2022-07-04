using Microsoft.AspNetCore.Mvc;
using SpNews.Data;
using SpNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpNews.Components
{
    public class NewsGroupsComponent : ViewComponent
    {
        private SpNewsContext _context;
        public NewsGroupsComponent(SpNewsContext context)
        {
            _context = context;

        }
        // a method that return its view
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _context.Categories
                 .Select(c => new ShowGroupViewModel()
                 {
                     GroupId = c.Id,
                     Name = c.Name,
                     NewsCount = _context.CategoryToNews.Count(g => g.CategoryId == c.Id)
                 }).ToList();
            return View("/Views/Components/NewsGroupsComponent.cshtml", categories);
        }

    }
}
