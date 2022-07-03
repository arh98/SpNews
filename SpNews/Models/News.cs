using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpNews.Models
{
    public class News
    {
   
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public ICollection<CategoryToNews> CategoryToNews { get; set; }

       
    }
}
