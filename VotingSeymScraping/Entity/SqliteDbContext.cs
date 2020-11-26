using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using VotingSeymSraping.Entity;

namespace VotingSeymSraping.Data
{
    public class SqliteDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:MyDatabase.sqlite");
            base.OnConfiguring(optionsBuilder);
        }

        


        public DbSet<Deputy> Deputies { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Vote> Votes { get; set; }


    }
}
