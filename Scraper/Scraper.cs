using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using VotingSeymSraping.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using VotingSeymSraping.Entity;
using VotingSeymSraping.Managers;

namespace Scraper
{
    public class Scraper
    {

        private BindingList<Deputy> _deputies = new BindingList<Deputy>();
        public BindingList<Deputy> Deputies
        {
            get { return _deputies; }
            set { _deputies = value; }
        }

        public void ScrapeData(string page)
        {
            var web = new HtmlWeb();
            var doc = web.Load(page);

            var DeputiesPage = doc.DocumentNode.SelectNodes(".//ul[@class = 'deputies']/li");

            foreach (var deputyPage in DeputiesPage)
            {
                var deputyName = HttpUtility.HtmlDecode(deputyPage.SelectSingleNode(".//div[@class = 'deputyName']").InnerText);
                var deputypartial = HttpUtility.HtmlDecode(deputyPage.SelectSingleNode(".//div[@class = 'deputy-box-details']/strong").InnerText);

                _deputies.Add(new Deputy{Name = deputyName, PoliticalParty = deputypartial} );
                
            }

            PersistDeputies(_deputies);

        }

        private void PersistDeputies(BindingList<Deputy> deputies)
        {
            foreach (var scappedDeputy in deputies)
            {
                Deputy deputy = new Deputy()
                {
                    Name = scappedDeputy.Name,
                    PoliticalParty = scappedDeputy.PoliticalParty,

                };

                Deputymanager dm = new Deputymanager();
                dm.AddDeputy(deputy);
            }

            //using (var dbContext = new SqliteDbContext())
            //{
            //    Deputy en = new Deputy();
            //    {
            //        en.Name = "aaa";
            //        en.PoliticalParty = "bbbb";
            //        //   EnvoysManager.AddEnvoys(en);
            //    }
            //    dbContext.Deputies.Add(en);
            //    dbContext.SaveChanges();


            //}


        }
    }
}
