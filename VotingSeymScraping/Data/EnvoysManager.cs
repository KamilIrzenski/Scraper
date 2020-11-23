using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSeymSraping.Entity;

namespace VotingSeymSraping.Data
{
   public class EnvoysManager
    {
        public static void AddEnvoys(Deputy en)
        {
            using (SqliteDbContext sqliteDbContext = new SqliteDbContext())
            {
                sqliteDbContext.Deputies.Add(en);
                sqliteDbContext.SaveChanges();
            }
        }


        public static List<Deputy> GetElements(SqliteDbContext sqliteDbContext)
        {
            return sqliteDbContext.Deputies.ToList();

        }

    }
}
//aaaaaaaaaaaaaaaaaaaaaaaaaa
//aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa