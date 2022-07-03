using Microsoft.EntityFrameworkCore;
using SpNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpNews.Data
{
    public class SpNewsContext : DbContext
    {
        // pass the setting of db to this clas with ctor
        // with using base() we pass the options to paretnt class ctor
        public SpNewsContext(DbContextOptions<SpNewsContext> options) : base(options)
        {
        }
        // models that should create table for them in db
        public DbSet<Category> Categories { get; set; }
    }
}
