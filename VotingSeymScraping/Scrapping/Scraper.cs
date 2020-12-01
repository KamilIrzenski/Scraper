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
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using VotingSeymSraping.Entity;
using VotingSeymSraping.Managers;

namespace Scraper
{
    public class Scraper
    {

        private BindingList<Deputy> _deputies = new BindingList<Deputy>();
        private BindingList<Meeting> _meetings = new BindingList<Meeting>();
        

        //public BindingList<LinkPage> LinkPages
        //{
        //    get { return _links; }

        //    set { _links = value; }


        //}

        public BindingList<Meeting> Meetings
        {
            get { return _meetings; }
            set { _meetings = value; }
        }

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

                _deputies.Add(new Deputy { Name = deputyName, PoliticalParty = deputypartial });

            }
        }

        public void ScrapeDataSitting(string page)
        {
            var web = new HtmlWeb();
            var doc = web.Load(page);

            var sittingSeymPage = doc.DocumentNode.SelectNodes(".//tbody/tr");

            foreach (var sittingPage in sittingSeymPage)
            {
               // var nrSitting = HttpUtility.HtmlDecode(sittingPage.SelectSingleNode(".//td[@class = 'center']").InnerText);
                var dateSitting = HttpUtility.HtmlDecode(sittingPage.SelectSingleNode(".//td[@class = 'left']").InnerText);
                var link = HttpUtility.HtmlDecode(sittingPage.SelectSingleNode(".//td[@class = 'left']/a").Attributes["href"].Value);
                _meetings.Add(new Meeting() { Links = link, DateOfVote = dateSitting});
                

            }

        }

        public void ScrapeDataOfDay(string page)
        {
            var web = new HtmlWeb();
            var doc = web.Load("https://www.sejm.gov.pl/sejm9.nsf/" + page);

            var votingDatePage = doc.DocumentNode.SelectNodes(".//tbody/tr");

            foreach (var votingPage in votingDatePage)
            {
                var nrLink = HttpUtility.HtmlDecode(votingPage.SelectSingleNode(".//td[@class = 'bold']/a")
                    .Attributes["href"].Value);
                var time = HttpUtility.HtmlDecode(votingPage.SelectSingleNode(".//td[2]").InnerText);
                var topic = HttpUtility.HtmlDecode(votingPage.SelectSingleNode(".//td[@class = 'left']").InnerText);
                //var link = HttpUtility.HtmlDecode(votingPage.SelectSingleNode(".//td[@class = 'left']/a").InnerText);

                _meetings.Add(new Meeting() { TimeOfVote = time, VotingTopic = topic });

            }
        }
    }
}




