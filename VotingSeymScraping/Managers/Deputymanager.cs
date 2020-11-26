using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSeymSraping.Data;
using VotingSeymSraping.Entity;

namespace VotingSeymSraping.Managers
{
    public class Deputymanager
    {
        public void AddDeputy(Deputy deputy)
        {
            using (SqliteDbContext context = new SqliteDbContext())
            {
                context.Deputies.Add(deputy);

                try
                {
                    context.SaveChanges();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }
    }
}
