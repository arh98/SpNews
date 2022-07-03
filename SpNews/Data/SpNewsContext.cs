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
        public DbSet<CategoryToNews> CategoryToNews{ get; set; }
        public DbSet<News> News { get; set; }

        //seeding some default data to db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region seed_Data_to_CategoryTB
            modelBuilder.Entity<Category>().HasData(
            new Category()
            {
                Id = 1,
                Name= "Foreign",
                Description = "News related to foreign sports competitions"
            },
            new Category()
            {
                Id = 2,
                Name = "Domestic",
                Description = "News about domestic competitions"
            },
            new Category()
            {
                Id = 3,
                Name = "Football",
                Description = "News about football competitions"
            },
            new Category()
            {
                Id = 4,
                Name = "Basketball",
                Description = "News about basketball competitions"
            },
            new Category()
            {
                Id = 5,
                Name = "Volleyball",
                Description = "News about volleyball competitions"
            });
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
