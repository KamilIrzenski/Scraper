using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSeymSraping.Entity
{
   public class Meeting
    {

        [Key]
        public int NrID { get; set; }
        public int NrMeetings { get; set; }
        public DateTime DateOfVote { get; set; }
        public DateTime TimeOfVote { get; set; }
        public string VotingTopic { get; set; }

        //public int NrVote
        //{

        //    get => NumberVote.;

        //    set => NumberVote.NumberVote = Convert.ToInt32(value);
        //}

    }
}
