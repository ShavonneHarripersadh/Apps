using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Punters
{
    public class Bet
    {
        [Key]
        public int BetID { get; set; }

        [ForeignKey("Market")]
        public int MarketID { get; set; }
        public Market Market{ get; set; }

        [ForeignKey("Punter")]
        public int PunterID { get; set; }
        public Punter Punter { get; set; }
     
        public decimal Odds { get; set; }
        public decimal Stake { get; set; }

        public decimal PotentialPayout { get; set; }


    }
}
