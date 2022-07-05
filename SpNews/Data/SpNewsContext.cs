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
        public DbSet<User> Users { get; set; }

        //seeding some default data to db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //introduce key for this table to prevent to prevent Error when migration
            modelBuilder.Entity<CategoryToNews>().HasKey( t => new { t.NewsId , t.CategoryId});
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
            modelBuilder.Entity<News>().HasData(
                new News
                {
                    Id = 1,
                    Name = "Cristiano Ronaldo wants to leave Manchester United this summer",
                    Description = "The 37-year-old feels the urge to win even more in the twilight of his career, but is understood to feel that may not be possible at Old Trafford next season. The 2021/22 campaign was the fifth in succession in which United failed to win a trophy.",
                    Date = "2022-07-03"
                },
                new News
                {
                    Id = 2,
                    Name = "Chelsea transfer news and rumours: Summer transfer window 2022",
                    Description= "Chelsea's bid has at this point trumped Arsenal, who had an opening bid rejected but are expected to go back in with an improved offer. Chelsea are also in for Raheem Sterling with Manchester City expecting to field a bid for the England international after Thomas Tuchel engaged Sterling over how he would fit in at Stamford Bridge.",
                    Date = "2022-07-03"
                },
                new News
                {
                    Id=3,
                    Name= "Man City transfer news and rumours: Summer transfer window 2022",
                    Description= "Manchester City are expecting to field an opening offer from Chelsea for Raheem Sterling after Thomas Tuchel engaged the England international over how he'd fit in at Stamford Bridge.The forward heads a shortlist of the manager's attacking targets and enters the final year of his contract with the Premier League champions, who are grateful for his service and will not obstruct his desire for greater minutes and status elsewhere.",
                    Date = "2022-07-03"
                });
            modelBuilder.Entity<CategoryToNews>().HasData(
                new CategoryToNews() { CategoryId = 1, NewsId = 1 },
                new CategoryToNews() { CategoryId = 1, NewsId = 2 },
                new CategoryToNews() { CategoryId = 1, NewsId = 3 },
                new CategoryToNews() { CategoryId = 3, NewsId = 1 },
                new CategoryToNews() { CategoryId = 2, NewsId = 2 },
                new CategoryToNews() { CategoryId = 3, NewsId = 3 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
