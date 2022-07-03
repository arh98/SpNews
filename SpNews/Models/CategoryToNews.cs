using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpNews.Models
{
    public class CategoryToNews
    {
        public int NewsId { get; set; }
        public int CategoryId { get; set; }

        //navigation property
        public Category Category { get; set; }
        public News News { get; set; }
    }
}
