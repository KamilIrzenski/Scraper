using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using VotingSeymSraping.Data;
using VotingSeymSraping.Entity;

namespace VotingSeymSraping
{
    public partial class Form1 : Form
    {
        List<Deputy> people = new List<Deputy>();
        private SqliteDbContext _sqliteDbContext = new SqliteDbContext();

        public Form1()
        {
            InitializeComponent();
            LoadEnvoyList();
        }

        private void WireUpPeopleList()
        {
            listEnvoysBox.DataSource = null;
            listEnvoysBox.DataSource = people;
            listEnvoysBox.DisplayMember = "FullName";
        }

        private void LoadEnvoyList()
        {
            people = EnvoysManager.GetElements(_sqliteDbContext);
            WireUpPeopleList();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text) && string.IsNullOrEmpty(textBoxLastName.Text))
            {
                MessageBox.Show("Podaj Imie i Nazwisko Posła");
            }
            else
            {
                using (var dbContext = new SqliteDbContext())
                {
                    Deputy en = new Deputy();
                    {
                        en.Name = textBoxName.Text;
                        en.PoliticalParty = textBoxPoliticalPartial.Text;
                        //   EnvoysManager.AddEnvoys(en);
                    }
                    dbContext.Deputies.Add(en);
                    dbContext.SaveChanges();

                    if (en.EnvoyID > 0)
                    {
                        MessageBox.Show("Id posła to " + en.EnvoyID);
                    }
                    else
                    {
                        MessageBox.Show("Błąd!");
                    }

                    LoadEnvoyList();

                    textBoxName.Text = "";
                    textBoxLastName.Text = "";
                    textBoxPoliticalPartial.Text = "";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Scraper.Scraper scrapper = new Scraper.Scraper();
            scrapper.ScrapeDataOfVote("https://www.sejm.gov.pl/sejm9.nsf/agent.xsp?symbol=klubglos&IdGlosowania=54381&KodKlubu=PiS");

            using (var dbContext = new SqliteDbContext())
            {

                dbContext.Database.ExecuteSqlCommand("DELETE FROM DEPUTIES");

                foreach (var dep in scrapper.Deputies)
                {
                    Deputy en = new Deputy();
                    {
                        en.Name = dep.Name;
                        en.PoliticalParty = dep.PoliticalParty;
                    }
                    dbContext.Deputies.Add(en);
                }

                dbContext.SaveChanges();
            }
        }
        List<Deputy> Deputies = new List<Deputy>();

        private void scraperMeetingsBtn_Click(object sender, EventArgs e)
        {

            List<Meeting> SrapedMeetings = new List<Meeting>();
            Scraper.Scraper scrapper = new Scraper.Scraper();
            scrapper.ScrapeDataSitting("https://www.sejm.gov.pl/sejm9.nsf/agent.xsp?symbol=posglos&NrKadencji=9");


            foreach (var meet in scrapper.Meetings)
            {

                Scraper.Scraper s2 = new Scraper.Scraper();
                s2.ScrapeDataOfDay(meet.DetailsLink);
                foreach (var meet2 in s2.Meetings)
                {
                    Meeting meeting2 = new Meeting();
                    meeting2.TimeOfVote = meet2.TimeOfVote;
                    meeting2.VotingTopic = meet2.VotingTopic;
                    meeting2.VotingLink = meet2.DetailsLink;

                    meeting2.NrMeetings = meet.NrMeetings;
                    meeting2.DateOfVote = meet.DateOfVote;


                    SrapedMeetings.Add(meeting2);

                    //listEnvoysBox.DataSource = s2.Meetings;
                    //listEnvoysBox.DisplayMember = "FullName";
                }


                
            }

            
            foreach (var meeting in SrapedMeetings)
            {
                Scraper.Scraper scraperParties = new Scraper.Scraper();
                scraperParties.ScrapeDataClubLink(meeting.VotingLink);

                foreach (var link in scraperParties.Links)
                {
                    Scraper.Scraper scrapevoting = new Scraper.Scraper();
                    scrapevoting.ScrapeDataOfVote(link.Link);

                    foreach (var votingItem in scrapevoting.VotingList)
                    {
                        Deputy deputy = Deputies.Where(x => x.Name == votingItem.Name && x.PoliticalParty == link.Party)
                            .FirstOrDefault();

                        if (null == deputy)
                        {
                            deputy = new Deputy() {Name = votingItem.Name, PoliticalParty = link.Party};
                            Deputies.Add(deputy);
                        }

                        Vote vote = new Vote()
                        {
                            Meeting = meeting,
                            Name = deputy,
                            VoteType = votingItem.Vote
                        };
                    }

                }


            }

        }
    }
}