using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpNews.Models
{
    public class DetailedViewModel
    {
        public News News { get; set; }
        public List<Category> Categories { get; set; }
    }
}
