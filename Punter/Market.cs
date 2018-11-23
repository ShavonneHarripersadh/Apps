using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Punters
{
    public class Market
    {
        [Key]
        public int MarketID { get; set; }

        [Required,StringLength(25)]
        public string MarketName { get; set; }

        [Required]
        public decimal Odds { get; set; }

        public static implicit operator Market(List<Market> v)
        {
            throw new NotImplementedException();
        }
    }
}
