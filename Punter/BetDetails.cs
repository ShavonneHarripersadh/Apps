using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Punters
{
    public class BetDetails
    {
        [Key]
        public int BetID { get; set; }
        public int PunterID { get; set; }
        public string PunterName { get; set; }
        public int MarketID { get; set; }
        public string MarketName { get; set; }
        public decimal Odds { get; set; }  
        public decimal Stake { get; set; }  
        public decimal PotentialPayout { get; set; }  
    }
}
