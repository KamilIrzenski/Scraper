using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                    dbContext.Add(en);
                    dbContext.SaveChanges();

                    if (en.DeputyID >0)
                    {
                        MessageBox.Show("Id posła to " + en.DeputyID);
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
    }
}
