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
        public string DateOfVote { get; set; }
        public string TimeOfVote { get; set; }
        public string VotingTopic { get; set; }
        public string DetailsLink { get; set; }
        public string VotingLink { get; set; }
        public string FullName
        {
            get { return $"ID: {NrMeetings}, {DateOfVote}, {TimeOfVote}, {VotingTopic} "; }

        }

    }
}
