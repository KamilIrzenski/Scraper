using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSeymSraping.Entity
{
    public class Deputy
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeputyID { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public string PoliticalParty { get; set; }

        public string FullName
        {
            get { return $"ID: {DeputyID}, {Name}, {PoliticalParty}"; }

        }
    }
}
