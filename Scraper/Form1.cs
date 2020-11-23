using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VotingSeymSraping.Data;
using VotingSeymSraping.Entity;


namespace Scraper
{
    public partial class Form1 : Form
    {

        Scraper scraper;

        public Form1()
        {
            InitializeComponent();
            scraper = new Scraper();
            deputiesListBox.DataSource = scraper.Deputies;
            deputiesListBox.DisplayMember = "FullName";

        }

        private void btnPageLoad_Click(object sender, EventArgs e)
        {
            scraper.ScrapeData(textBoxPage.Text);


        }//sssssssssssssssssssssssssssssss
    }
}