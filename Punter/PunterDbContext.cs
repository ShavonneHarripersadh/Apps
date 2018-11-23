using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Punters
{
    public class PunterDbContext :DbContext
    {
        public PunterDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Punter> Punter { get; set; }
        public DbSet<Market> Market { get; set; }
        public DbSet<Bet> Bet { get; set; }
        public DbSet<BetDetails> BetDetails { get; set; }
    }
}
