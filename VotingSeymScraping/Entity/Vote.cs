using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSeymSraping.Entity
{

    public enum VoteType
    {
        Z,
        P,
        W,
        N
    }

    public class Vote
    {
        [Key]
        public int VoteID { get; set; }
        public VoteType? VoteType { get; set; }
        
        public Deputy Name { get; set; }
        
        public Meeting Meeting { get; set; }


        public string NameEnvoy
        {

            get => Name.Name;

            set => Name.Name = value;
        }
        
    }

}
