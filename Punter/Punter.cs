using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Punters
{
    public class Punter
    {
        [Key]
        public int PunterID { get; set; }

        [Required, StringLength(25)]
        public string PunterName { get; set; }

        [Required]
        public decimal Balance { get; set; }
    }
}
